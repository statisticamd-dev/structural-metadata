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

namespace Presentation.Application.MeasurementTypes.Queries.GetMeasurementTypes
{
    public class GetMeasurementTypesQuery : AbstractRequest, IRequest<MeasurementTypesVm>
    {
        public class GetMeasurementTypesQueryHandler : IRequestHandler<GetMeasurementTypesQuery, MeasurementTypesVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetMeasurementTypesQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MeasurementTypesVm> Handle(GetMeasurementTypesQuery request, CancellationToken cancellationToken)
            {
                var measurementTypes = await _context.MeasurementTypes
                    .AsNoTracking()
                    .ProjectTo<MeasurementTypeDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(mu => mu.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new MeasurementTypesVm
                {
                    MeasurementTypes = measurementTypes
                };

                return vm;
            }
        }
    }
}