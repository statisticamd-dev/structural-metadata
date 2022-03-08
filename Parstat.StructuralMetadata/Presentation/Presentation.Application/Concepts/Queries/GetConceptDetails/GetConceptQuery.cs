using System;
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

namespace Presentation.Application.Concepts.Queries.GetConceptDetails
{
    public class GetConceptQuery : AbstractRequest, IRequest<ConceptVm>
    {
        public long Id { get; set; }
        public class GetConceptQueryHandler : IRequestHandler<GetConceptQuery, ConceptVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetConceptQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ConceptVm> Handle(GetConceptQuery request, CancellationToken cancellationToken)
            {
                var concept = await _context.Concepts
                    .Where(c => c.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<ConceptDetailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new ConceptVm
                {
                    Concept = concept
                };

                return vm;
            }
        }
    }
}
