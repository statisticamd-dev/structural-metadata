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

namespace Presentation.Application.Variables.Queries.GetVariableList
{
    public class GetVariableListQuery : AbstractRequest, IRequest<VariableListVm>
    {
        public string Name { get; set; }

        public class GetVariableListQueryHandler : IRequestHandler<GetVariableListQuery, VariableListVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetVariableListQueryHandler(IStructuralMetadataDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VariableListVm> Handle(GetVariableListQuery request, CancellationToken cancellationToken)
            {
                var variablesQuery = CreateQuery(request.Name, request.Language);
                var variables = await variablesQuery
                    .AsNoTracking()
                    .ProjectTo<VariableDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { ["language"] = request.Language })
                    .OrderBy(v => v.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new VariableListVm
                {
                    Variables = variables
                };

                return vm;
            }

            private IQueryable<Variable> CreateQuery(string name, string language)
            {
                if (string.IsNullOrWhiteSpace(name)) return _context.Variables;

                return language switch
                {
                    "en" => _context.Variables.Where(ns => EF.Functions.ILike(ns.Name.En.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ru" => _context.Variables.Where(ns => EF.Functions.ILike(ns.Name.Ru.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ro" => _context.Variables.Where(ns => EF.Functions.ILike(ns.Name.Ro.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    _ => _context.Variables,
                };
            }
        }
    }
}