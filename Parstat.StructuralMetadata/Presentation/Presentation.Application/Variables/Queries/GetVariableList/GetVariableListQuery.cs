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

namespace Presentation.Application.Variables.Queries.GetVariableList
{
    public class GetVariableListQuery : AbstractRequest, IRequest<VariableListVm>
    {
        public class GetVariableListQueryHandler : IRequestHandler<GetVariableListQuery, VariableListVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetVariableListQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VariableListVm> Handle(GetVariableListQuery request, CancellationToken cancellationToken)
            {
                var variables = await _context.Variables
                    .AsNoTracking()
                    .ProjectTo<VariableDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(v => v.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new VariableListVm
                {
                    Variables = variables
                };

                return vm;
            }
        }
        


    }
}