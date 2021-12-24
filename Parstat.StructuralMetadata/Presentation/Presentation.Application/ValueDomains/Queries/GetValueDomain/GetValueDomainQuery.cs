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

namespace Presentation.Application.ValueDomains.Queries.GetValueDomain
{
    public class GetValueDomainQuery : AbstractRequest, IRequest<ValueDomainVm>
    {
        public long Id { get; set; }

        public class GetValueDomainQueryHandler : IRequestHandler<GetValueDomainQuery, ValueDomainVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetValueDomainQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ValueDomainVm> Handle(GetValueDomainQuery request, CancellationToken cancellationToken)
            {
                var valueDomain = await _context.ValueDomains
                    .Where(v => v.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<ValueDomainDetailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new ValueDomainVm
                {
                    ValueDomain = valueDomain
                };

                return vm;
            }
        }
    }
}