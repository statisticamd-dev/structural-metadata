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

namespace Presentation.Application.MeasurementTypes.Queries.GetMeasurementTypes
{
    public class GetMeasurementTypesQuery : AbstractRequest, IRequest<MeasurementTypesVm>
    {
        public string Name { get; set; }
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
                var measurementTypesQuery = CreateQuery(request.Name, request.Language);
                var measurementTypes = await measurementTypesQuery
                    .AsNoTracking()
                    .ProjectTo<MeasurementTypeDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { ["language"] = request.Language })
                    .OrderBy(mu => mu.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new MeasurementTypesVm
                {
                    MeasurementTypes = measurementTypes
                };

                return vm;
            }

            private IQueryable<MeasurementType> CreateQuery(string name, string language)
            {
                if (string.IsNullOrWhiteSpace(name)) return _context.MeasurementTypes;

                return language switch
                {
                    "en" => _context.MeasurementTypes.Where(ns => EF.Functions.ILike(ns.Name.En.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ru" => _context.MeasurementTypes.Where(ns => EF.Functions.ILike(ns.Name.Ru.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ro" => _context.MeasurementTypes.Where(ns => EF.Functions.ILike(ns.Name.Ro.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    _ => _context.MeasurementTypes,
                };
            }
        }
    }
}