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
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnits
{
    public class GetMeasurementUnitsQuery : AbstractRequest, IRequest<MeasurementUnitsVm>
    {
        public string Name { get; set; }

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
                var measurementUnitsQuery = CreateQuery(request.Name, request.Language);
                var measurementUnits = await measurementUnitsQuery
                    .AsNoTracking()
                    .ProjectTo<MeasurementUnitDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { ["language"] = request.Language })
                    .OrderBy(mu => mu.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new MeasurementUnitsVm
                {
                    MeasurementUnits = measurementUnits
                };

                return vm;
            }

            private IQueryable<MeasurementUnit> CreateQuery(string name, string language)
            {
                if (string.IsNullOrWhiteSpace(name)) return _context.MeasurementUnits;

                return language switch
                {
                    "en" => _context.MeasurementUnits.Where(ns => EF.Functions.ILike(ns.Name.En.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ru" => _context.MeasurementUnits.Where(ns => EF.Functions.ILike(ns.Name.Ru.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ro" => _context.MeasurementUnits.Where(ns => EF.Functions.ILike(ns.Name.Ro.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    _ => _context.MeasurementUnits,
                };
            }
        }
    }
}