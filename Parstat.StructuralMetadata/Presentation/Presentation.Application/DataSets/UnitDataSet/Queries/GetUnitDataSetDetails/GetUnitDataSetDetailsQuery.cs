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

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails
{
    public class GetUnitDataSetDetailsQuery : AbstractRequest, IRequest<UnitDataSetVm>
    {
        public long Id { get; set; }

        public class GetUnitDataSetDetailsQueryHandler : IRequestHandler<GetUnitDataSetDetailsQuery, UnitDataSetVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetUnitDataSetDetailsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UnitDataSetVm> Handle(GetUnitDataSetDetailsQuery request, CancellationToken cancellationToken)
            {
                var unitDataSet = await _context.DataSets
                        .Where(ds => ds.Id == request.Id)
                        .AsNoTrackingWithIdentityResolution()
                        .ProjectTo<UnitDataSetDetailsDto>(_mapper.ConfigurationProvider,
                                                                 new Dictionary<string, object> { ["language"] = request.Language })
                        .SingleOrDefaultAsync(cancellationToken);
                var vm = new UnitDataSetVm
                {
                    UnitDataSet = unitDataSet
                };

                return vm;
            }
        }
    }
}
