using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentedVariablesQuery
{
    public class GetRepresentedVariablesQuery : AbstractRequest, IRequest<RepresentedVariablesVm>
    {
        public long VariableId { get; set; }

        public class GetRepresentedVariableQueryHandler : IRequestHandler<GetRepresentedVariablesQuery, RepresentedVariablesVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetRepresentedVariableQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RepresentedVariablesVm> Handle(GetRepresentedVariablesQuery request, CancellationToken cancellationToken)
            {
                var representedVariables = await _context.RepresentedVariables
                    .Where(v => v.VariableId == request.VariableId)
                    .AsNoTracking()
                    .ProjectTo<RepresentedVariableDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .ToListAsync(cancellationToken);

                var vm = new RepresentedVariablesVm
                {
                    Representations = representedVariables
                };

                return vm;
            }
        }
    }
}