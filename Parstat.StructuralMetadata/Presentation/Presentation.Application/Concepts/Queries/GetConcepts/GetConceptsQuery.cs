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

namespace Presentation.Application.Concepts.Queries.GetConcepts
{
    public class GetConceptsQuery : AbstractRequest, IRequest<ConceptsVm>
    {
        public class GetConceptsQueryHandler : IRequestHandler<GetConceptsQuery, ConceptsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetConceptsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ConceptsVm> Handle(GetConceptsQuery request, CancellationToken cancellationToken)
            {
                var concepts = await _context.Concepts
                    .AsNoTracking()
                    .ProjectTo<ConceptDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(mu => mu.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new ConceptsVm
                {
                    Concepts = concepts
                };

                return vm;
            }
        }
        
    }
}
