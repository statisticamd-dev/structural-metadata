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

namespace Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnits
{
    public class GetMeasurementUnitsQuery : AbstractRequest, IRequest<MeasurementUnitsVm>
    {
        public class GetMeasurementUnitsQueryHandler : IRequestHandler<GetMeasurementUnitsQuery, MeasurementUnitsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetMeasurementUnitsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MeasurementUnitsVm> Handle(GetMeasurementUnitsQuery request, CancellationToken cancellationToken)
            {
                var measurementUnits = await _context.MeasurementUnits
                    .AsNoTracking()
                    .ProjectTo<MeasurementUnitDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(mu => mu.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new MeasurementUnitsVm
                {
                    MeasurementUnits = measurementUnits
                };

                return vm;
            }
        }
    }
}