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

namespace Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetStatisticalClassificationLevels
{
    public class GetStatisticalClassificationLevelsQuery : AbstractRequest, IRequest<StatisticalClassificationLevelsVm>
    {
        public long Id { get; set; }

         public class GetStatisticalClassificationQueryHandler : IRequestHandler<GetStatisticalClassificationLevelsQuery, StatisticalClassificationLevelsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetStatisticalClassificationQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<StatisticalClassificationLevelsVm> Handle(GetStatisticalClassificationLevelsQuery request, CancellationToken cancellationToken)
            {
                var statisticalClassificationLevels = await _context.Levels
                        .Where(l => l.NodeSetId == request.Id)
                        .AsNoTrackingWithIdentityResolution()
                        .ProjectTo<LevelTinyDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                        //.Where(sc => sc.Id == request.Id)
                        .ToListAsync(cancellationToken);

                var vm = new StatisticalClassificationLevelsVm
                {
                    Levels = statisticalClassificationLevels
                };

                return vm;
            }
        }

    }
}
