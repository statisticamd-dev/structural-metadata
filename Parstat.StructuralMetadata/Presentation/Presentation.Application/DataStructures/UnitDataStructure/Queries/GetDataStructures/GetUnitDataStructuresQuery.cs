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
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructures
{
    public class GetUnitDataStructuresQuery : AbstractRequest, IRequest<UnitDataStructuresVm>
    {
        public string Name { get; set; }

        public class GetDataStructuresQueryHandler : IRequestHandler<GetUnitDataStructuresQuery, UnitDataStructuresVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetDataStructuresQueryHandler(IStructuralMetadataDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UnitDataStructuresVm> Handle(GetUnitDataStructuresQuery request, CancellationToken cancellationToken)
            {
                var dataStructuresQuery = CreateQuery(request.Name, request.Language);
                var unitDataStructures = await dataStructuresQuery
                    .Where(ds => ds.Type == DataSetType.UNIT)
                    .AsNoTracking()
                    .ProjectTo<UnitDataStructureTinyDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { ["language"] = request.Language })
                    .OrderBy(v => v.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new UnitDataStructuresVm
                {
                    UnitDataStructures = unitDataStructures
                };

                return vm;
            }

            private IQueryable<DataStructure> CreateQuery(string name, string language)
            {
                if (string.IsNullOrWhiteSpace(name)) return _context.DataStructures;

                return language switch
                {
                    "en" => _context.DataStructures.Where(ns => EF.Functions.ILike(ns.Name.En.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ru" => _context.DataStructures.Where(ns => EF.Functions.ILike(ns.Name.Ru.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ro" => _context.DataStructures.Where(ns => EF.Functions.ILike(ns.Name.Ro.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    _ => _context.DataStructures,
                };
            }
        }
        
    }
}
