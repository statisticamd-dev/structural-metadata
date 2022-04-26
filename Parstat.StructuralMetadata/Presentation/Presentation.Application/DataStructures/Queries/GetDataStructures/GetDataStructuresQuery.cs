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
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataStructures.Queries.GetDataStructures
{
    public class GetDataStructuresQuery : AbstractRequest, IRequest<DataStructuresVm>
    {
        public string Name { get; set; }

        public class GetDataStructuresQueryHandler : IRequestHandler<GetDataStructuresQuery, DataStructuresVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetDataStructuresQueryHandler(IStructuralMetadataDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DataStructuresVm> Handle(GetDataStructuresQuery request, CancellationToken cancellationToken)
            {
                var dataStructuresQuery = CreateQuery(request.Name, request.Language);
                var dataStructures = await dataStructuresQuery
                    .AsNoTracking()
                    .ProjectTo<DataStructureDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { ["language"] = request.Language })
                    .OrderBy(v => v.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new DataStructuresVm
                {
                    DataStructures = dataStructures
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
