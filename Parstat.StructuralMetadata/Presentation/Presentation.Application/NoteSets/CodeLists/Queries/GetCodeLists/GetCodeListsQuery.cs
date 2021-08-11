using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Application.NoteSets.CodeLists.Queries.GetCodeLists
{
    public class GetCodeListsQuery : IRequest<CodeListsVm>
    {
        public class GetCodeListsQueryHandler : IRequestHandler<GetCodeListsQuery, CodeListsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetCodeListsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CodeListsVm> Handle(GetCodeListsQuery request, CancellationToken cancellationToken)
            {
                var codeLists = await _context.NodeSets
                    .Where(ns => ns.NodeSetType == NodeSetType.CODE_LIST)
                    .ProjectTo<CodeListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(cl => cl.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new CodeListsVm
                {
                    CodeLists = codeLists
                };

                return vm;
            }
        }
    }
}