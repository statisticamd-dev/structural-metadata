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

namespace Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetStatisticalClassifications
{
    public class GetStatisticalClassificationsQuery : AbstractRequest, IRequest<StatisticalClassificationsVm>
    {
        public class GetStatisticalClassificationsQueryHandler : IRequestHandler<GetStatisticalClassificationsQuery, StatisticalClassificationsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetStatisticalClassificationsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StatisticalClassificationsVm> Handle(GetStatisticalClassificationsQuery request, CancellationToken cancellationToken)
            {
                var statisticalClassifications = await _context.NodeSets
                    .Where(ns => ns.NodeSetType == NodeSetType.STATISTICAL_CLASSIFICATION)
                    .AsNoTracking()
                    .ProjectTo<StatisticalClassificationDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(cl => cl.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new StatisticalClassificationsVm
                {
                    StatisticalClassifications = statisticalClassifications
                };

                return vm;
            }
        }
    }
}