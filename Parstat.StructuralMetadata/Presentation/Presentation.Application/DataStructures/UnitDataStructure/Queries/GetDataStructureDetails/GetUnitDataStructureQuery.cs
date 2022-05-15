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

namespace Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails
{
    public class GetUnitDataStructureQuery : AbstractRequest, IRequest<UnitDataStructureVm>
    {
        public long Id { get; set; }

         public class GetDataStructureQueryHandler : IRequestHandler<GetUnitDataStructureQuery, UnitDataStructureVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetDataStructureQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UnitDataStructureVm> Handle(GetUnitDataStructureQuery request, CancellationToken cancellationToken)
            {
                var dataStructure = await _context.DataStructures
                        .Where(ds => ds.Id == request.Id)
                        .AsNoTrackingWithIdentityResolution()
                        .ProjectTo<UnitDataStructureDetailsDto>(_mapper.ConfigurationProvider,
                                                                 new Dictionary<string, object> { ["language"] = request.Language })
                        .SingleOrDefaultAsync(cancellationToken);
                var vm = new UnitDataStructureVm
                {
                    UnitDataStructure = dataStructure
                };

                return vm;
            }
        }
    }
}
