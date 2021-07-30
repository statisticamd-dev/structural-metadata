using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;

namespace Presentation.Application.Variables.Queries.GetVariableDetails
{
    public class GetVariableQuery : IRequest<VariableVm>
    {
        public long Id { get; set; }
        public class GetVariableListQueryHandler : IRequestHandler<GetVariableQuery, VariableVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetVariableListQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VariableVm> Handle(GetVariableQuery request, CancellationToken cancellationToken)
            {
                var variable = await _context.Variables
                    .Where(v => v.Id == request.Id)
                    .ProjectTo<VariableDetailsDto>(_mapper.ConfigurationProvider)
                    .OrderBy(v => v.Name)
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