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
    public class GetCorrespondencesQuery : AbstractRequest, IRequest<CorrespondencesVm>
    {
        public class GetCorrespondencesQueryHandler : IRequestHandler<GetCorrespondencesQuery, CorrespondencesVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetCorrespondencesQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CorrespondencesVm> Handle(GetCorrespondencesQuery request, CancellationToken cancellationToken)
            {
                var correspondences = await _context.Correspondences
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