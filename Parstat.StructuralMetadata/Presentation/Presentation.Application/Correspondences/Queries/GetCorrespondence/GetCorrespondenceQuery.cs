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

namespace Presentation.Application.Correspondences.Queries.GetCorrespondence
{
    public class GetCorrespondenceQuery : AbstractRequest, IRequest<CorrespondenceVm>
    {
        public long Id { get; set; }

        public class GetCorrespondenceQueryHandler : IRequestHandler<GetCorrespondenceQuery, CorrespondenceVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetCorrespondenceQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CorrespondenceVm> Handle(GetCorrespondenceQuery request, CancellationToken cancellationToken)
            {
                var correspondence = await _context.Correspondences
                    .Where(c => (c.Id == request.Id))
                    .AsNoTracking()
                    .ProjectTo<CorrespondenceDeteailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new CorrespondenceVm
                {
                    Correspondence = correspondence
                };

                return vm;
            }
        }
    }
}