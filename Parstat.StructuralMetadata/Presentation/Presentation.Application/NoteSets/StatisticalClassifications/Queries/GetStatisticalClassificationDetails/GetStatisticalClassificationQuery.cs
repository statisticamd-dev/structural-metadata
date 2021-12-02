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
                StatisticalClassificationDetailsDto statisticalClassification = await _context.NodeSets
                    .Where(ns => ns.Id == request.Id && ns.NodeSetType == NodeSetType.STATISTICAL_CLASSIFICATION)
                    .Include(ns => ns.Nodes.Where(n => n.Parent == null))
                    .AsNoTrackingWithIdentityResolution()
                    .ProjectTo<StatisticalClassificationDetailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    //.Where(sc => sc.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);
                if(statisticalClassification != null && statisticalClassification.RootItems != null) 
                {
                    statisticalClassification.RootItems.ForEach(ri => ri.Children = getChildren(ri.Id, request.Language));
                }

                var vm = new StatisticalClassificationVm
                {
                    StatisticalClassification = statisticalClassification
                };

                return vm;
            }

            private List<StatisticalClassificationItemDto> getChildren(long parentId, string language) 
            {
            
                var nodes = _context.Nodes.Where(n => n.ParentId == parentId)
                    .AsNoTrackingWithIdentityResolution()
                    .ProjectTo<StatisticalClassificationItemDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = language})
                    .ToList();
                if(nodes != null && nodes.Count > 0)
                {
                    nodes.ForEach(n => n.Children = getChildren(n.Id, language));
                }

                return nodes;
            }
        }
    }
}