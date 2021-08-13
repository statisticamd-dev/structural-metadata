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

namespace Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnit
{
    public class GetMeasurementUnitQuery : AbstractRequest, IRequest<MeasurementUnitVm>
    {
        public long Id { get; set; }

         public class GetMeasurementUnitQueryHandler : IRequestHandler<GetMeasurementUnitQuery, MeasurementUnitVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetMeasurementUnitQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MeasurementUnitVm> Handle(GetMeasurementUnitQuery request, CancellationToken cancellationToken)
            {
                var measurementUnit = await _context.MeasurementUnits
                    .Where(m => m.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<MeasurementUnitDetailDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(mu => mu.LocalId)
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new MeasurementUnitVm
                {
                    MeasurementUnit = measurementUnit
                };

                return vm;
            }
        }
    }
}