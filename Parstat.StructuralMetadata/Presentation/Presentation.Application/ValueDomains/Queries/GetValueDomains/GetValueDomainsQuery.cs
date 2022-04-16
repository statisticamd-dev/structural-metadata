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

namespace Presentation.Application.ValueDomains.Queries.GetValueDomains
{
    public class GetValueDomainsQuery : AbstractRequest, IRequest<ValueDomainListVm>
    {
        public string Name { get; set; }
        public class GetValueDomainsQueryHandler : IRequestHandler<GetValueDomainsQuery, ValueDomainListVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetValueDomainsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ValueDomainListVm> Handle(GetValueDomainsQuery request, CancellationToken cancellationToken)
            {
                var valueDomainQuery = CreateQuery(request.Name, request.Language);
                var valueDomains = await valueDomainQuery
                    .AsNoTracking()
                    .ProjectTo<ValueDomainDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { ["language"] = request.Language })
                    .OrderBy(v => v.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new ValueDomainListVm
                {
                    ValueDomains = valueDomains
                };

                return vm;
            }

            private IQueryable<ValueDomain> CreateQuery(string name, string language)
            {
                if (string.IsNullOrWhiteSpace(name)) return _context.ValueDomains;

                return language switch
                {
                    "en" => _context.ValueDomains.Where(ns => EF.Functions.ILike(ns.Name.En.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ru" => _context.ValueDomains.Where(ns => EF.Functions.ILike(ns.Name.Ru.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    "ro" => _context.ValueDomains.Where(ns => EF.Functions.ILike(ns.Name.Ro.ToUpper(), $"%{name.ToUpper()}%") || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")),
                    _ => _context.ValueDomains,
                };
            }
        }
    }
}