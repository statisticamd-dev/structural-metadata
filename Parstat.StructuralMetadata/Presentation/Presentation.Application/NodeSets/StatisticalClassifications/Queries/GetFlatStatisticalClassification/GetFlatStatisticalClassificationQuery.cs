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
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetFlatStatisticalClassification
{
    public class GetFlatStatisticalClassificationQuery : AbstractRequest, IRequest<StatisticalClassificationFlatVm>
    {
        public long Id { get; set; }

        public class GetFlatStatisticalClassificationQueryHandler : IRequestHandler<GetFlatStatisticalClassificationQuery, StatisticalClassificationFlatVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetFlatStatisticalClassificationQueryHandler(IStructuralMetadataDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StatisticalClassificationFlatVm> Handle(GetFlatStatisticalClassificationQuery request, CancellationToken cancellationToken)
            {
                StatisticalClassificationFlatDto statisticalClassification = await _context.NodeSets
                    .Where(ns => ns.Id == request.Id && ns.NodeSetType == NodeSetType.STATISTICAL_CLASSIFICATION)
                    //.Include(ns => ns.Levels)
                    .Include(ns => ns.Nodes)
                    .AsNoTrackingWithIdentityResolution()
                    .ProjectTo<StatisticalClassificationFlatDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { ["language"] = request.Language })
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new StatisticalClassificationFlatVm
                {
                    StatisticalClassification = statisticalClassification
                };

                return vm;
            }
        }
    }
}