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
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetStatisticalClassifications
{
    public class GetStatisticalClassificationsQuery : AbstractRequest, IRequest<StatisticalClassificationsVm>
    {
        public string Name { get; set; }
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
                var statisticalClassifications = await createQuery(request.Name, request.Language)
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

            private IQueryable<NodeSet> createQuery(string name, string language) 
            {

                IQueryable<NodeSet> nodeSetsQuery =  _context.NodeSets
                    .Where(ns => ns.NodeSetType == NodeSetType.STATISTICAL_CLASSIFICATION);

                if (!String.IsNullOrEmpty(name))
                {
                    if(language == "en")
                    {
                        nodeSetsQuery = nodeSetsQuery.Where( ns => EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%")
                                                  || EF.Functions.ILike(ns.Name.En.ToUpper(), $"%{name.ToUpper()}%"));
                    }
                    if(language == "ro")
                    {
                        nodeSetsQuery = nodeSetsQuery.Where( ns => EF.Functions.ILike(ns.Name.Ro.ToUpper(), $"%{name.ToUpper()}%")
                                                  || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%"));
                    }
                    if(language == "ro")
                    {
                        nodeSetsQuery = nodeSetsQuery.Where( ns => EF.Functions.ILike(ns.Name.Ro.ToUpper(), $"%{name.ToUpper()}%")
                                                  || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%"));
                    }
                }

                return nodeSetsQuery;
            }
        }
    }
}