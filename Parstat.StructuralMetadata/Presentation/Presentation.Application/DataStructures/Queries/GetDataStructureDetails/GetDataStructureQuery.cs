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

namespace Presentation.Application.DataStructures.Queries.GetDataStructureDetails
{
    public class GetDataStructureQuery : AbstractRequest, IRequest<DataStructureVm>
    {
        public long Id { get; set; }

         public class GetDataStructureQueryHandler : IRequestHandler<GetDataStructureQuery, DataStructureVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetDataStructureQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DataStructureVm> Handle(GetDataStructureQuery request, CancellationToken cancellationToken)
            {
                var dataStructure = await _context.DataStructures
                        .Where(ds => ds.Id == request.Id)
                        .AsNoTrackingWithIdentityResolution()
                        .ProjectTo<DataStructureDetailsDto>(_mapper.ConfigurationProvider,
                                                                 new Dictionary<string, object> { ["language"] = request.Language })
                        .SingleOrDefaultAsync(cancellationToken);
                var vm = new DataStructureVm
                {
                    DataStructure = dataStructure
                };

                return vm;
            }
        }
    }
}
