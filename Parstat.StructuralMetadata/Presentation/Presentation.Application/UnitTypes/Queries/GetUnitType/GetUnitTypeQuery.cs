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

namespace Presentation.Application.UnitTypes.Queries.GetUnitType
{
    public class GetUnitTypeQuery : AbstractRequest, IRequest<UnitTypeVm>
    {
        public long Id { get; set; }

         public class GetUnitTypeQueryHandler : IRequestHandler<GetUnitTypeQuery, UnitTypeVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetUnitTypeQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UnitTypeVm> Handle(GetUnitTypeQuery request, CancellationToken cancellationToken)
            {
                var unitType = await _context.UnitTypes
                    .Where(u => u.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<UnitTypeDetailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new UnitTypeVm
                {
                    UnitType = unitType
                };

                return vm;
            }
        }
        
    }
}