using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;

namespace Presentation.Application.NoteSets.CodeLists.Queries.GetCodeListDetails
{
    public class GetCodeListDetailsQuery: IRequest<CodeListVm>
    {
        public long Id { get; set; }
        public class GetCodeListDetailsHandler : IRequestHandler<GetCodeListDetailsQuery, CodeListVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetCodeListDetailsHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CodeListVm> Handle(GetCodeListDetailsQuery request, CancellationToken cancellationToken)
            {
                var codeList = await _context.NodeSets
                    .Where(ns => ns.Id == request.Id)
                    .ProjectTo<CodeListDetailsDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new CodeListVm
                {
                    CodeList = codeList
                };

                return vm;
            }
        }
    }
}