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

namespace Presentation.Application.MeasurementTypes.Queries.GetMeasurementType
{
    public class GetMeasurementTypeQuery : AbstractRequest, IRequest<MeasurementTypeVm>
    {
        public long Id { get; set; }

         public class GetMeasurementUnitQueryHandler : IRequestHandler<GetMeasurementTypeQuery, MeasurementTypeVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetMeasurementUnitQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MeasurementTypeVm> Handle(GetMeasurementTypeQuery request, CancellationToken cancellationToken)
            {
                var measurementType = await _context.MeasurementTypes
                    .Where(m => m.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<MeasurementTypeDetailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(mu => mu.LocalId)
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new MeasurementTypeVm
                {
                    MeasurementType = measurementType
                };

                return vm;
            }
        }
    }
}