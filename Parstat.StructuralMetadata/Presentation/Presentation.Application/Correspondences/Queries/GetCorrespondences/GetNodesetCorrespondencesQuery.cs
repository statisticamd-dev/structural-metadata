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

namespace Presentation.Application.Correspondences.Queries.GetCorrespondences
{
    public class GetNodesetCorrespondencesQuery : AbstractRequest, IRequest<CorrespondencesVm>
    {
        public long NodeSetId { get; set; }

        public class GetNodesetCorrespondencesQueryHandler : IRequestHandler<GetNodesetCorrespondencesQuery, CorrespondencesVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetNodesetCorrespondencesQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CorrespondencesVm> Handle(GetNodesetCorrespondencesQuery request, CancellationToken cancellationToken)
            {
                var correspondences = await _context.Correspondences
                    .Where(c => (c.SourceId == request.NodeSetId || c.TargetId == request.NodeSetId) )
                    .AsNoTracking()
                    .ProjectTo<CorrespondenceDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .ToListAsync(cancellationToken);

                var vm = new CorrespondencesVm
                {
                    Correspondences = correspondences
                };

                return vm;
            }
        }
    }
}