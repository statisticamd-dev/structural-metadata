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

namespace Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails
{
    public class GetStatisticalClassificationQuery : AbstractRequest, IRequest<StatisticalClassificationVm>
    {
        public long Id { get; set; }

         public class GetStatisticalClassificationQueryHandler : IRequestHandler<GetStatisticalClassificationQuery, StatisticalClassificationVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetStatisticalClassificationQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<StatisticalClassificationVm> Handle(GetStatisticalClassificationQuery request, CancellationToken cancellationToken)
            {
                var statisticalClassification = await _context.NodeSets
                    .Where(ns => ns.Id == request.Id && ns.NodeSetType == NodeSetType.STATISTICAL_CLASSIFICATION)
                    //.Include(ns => ns.Nodes.Where(n => n.Parent == null))
                    .AsNoTrackingWithIdentityResolution()
                    .ProjectTo<StatisticalClassificationDetailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new StatisticalClassificationVm
                {
                    StatisticalClassification = statisticalClassification
                };

                return vm;
            }
        }
    }
}