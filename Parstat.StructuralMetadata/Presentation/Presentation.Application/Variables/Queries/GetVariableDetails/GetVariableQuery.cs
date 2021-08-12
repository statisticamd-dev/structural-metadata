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

namespace Presentation.Application.Variables.Queries.GetVariableDetails
{
    public class GetVariableQuery : AbstractRequest, IRequest<VariableVm>
    {
        public long Id { get; set; }
        public class GetVariableQueryHandler : IRequestHandler<GetVariableQuery, VariableVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetVariableQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VariableVm> Handle(GetVariableQuery request, CancellationToken cancellationToken)
            {
                var variable = await _context.Variables
                    .Where(v => v.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<VariableDetailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new VariableVm
                {
                    Variable = variable
                };

                return vm;
            }
        }
    }
}