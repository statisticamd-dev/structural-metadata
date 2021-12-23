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

namespace Presentation.Application.ValueDomains.Queries.GetValueDomains
{
    public class GetValueDomainsQuery : AbstractRequest, IRequest<ValueDomainVm>
    {
        public class GetValueDomainsQueryHandler : IRequestHandler<GetValueDomainsQuery, ValueDomainVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetValueDomainsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ValueDomainVm> Handle(GetValueDomainsQuery request, CancellationToken cancellationToken)
            {
                var valueDomains = await _context.ValueDomains
                    .AsNoTracking()
                    .ProjectTo<ValueDomainDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(v => v.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new ValueDomainVm
                {
                    ValueDomains = valueDomains
                };

                return vm;
            }
        }
    }
}