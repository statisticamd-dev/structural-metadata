using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails
{
    public class GetUnitDataSetDetailsQuery : AbstractRequest, IRequest<UnitDataSetDetailsVm>
    {
        public long Id { get; set; }

        public class GetUnitDataSetDetailsQueryHandler : IRequestHandler<GetUnitDataSetDetailsQuery, UnitDataSetDetailsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetUnitDataSetDetailsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UnitDataSetDetailsVm> Handle(GetUnitDataSetDetailsQuery request, CancellationToken cancellationToken)
            {
                //var unitDataSet = await _context.DataSets
                //        .Where(ds => ds.Id == request.Id)
                //        .AsNoTrackingWithIdentityResolution()
                //        .ProjectTo<UnitDataSetDetailsDto>(_mapper.ConfigurationProvider,
                //                                                 new Dictionary<string, object> { ["language"] = request.Language })
                //        .SingleOrDefaultAsync(cancellationToken);

                /* Enian: Changed to the below statement due to sqlite error: 
                  System.InvalidOperationException : Translating this query requires APPLY operation in SQL which is not supported on SQLite. */
                var unitDataSet = await _context.DataSets
                        .Where(ds => ds.Id == request.Id)
                        .AsNoTrackingWithIdentityResolution()                      
                        .SingleOrDefaultAsync(cancellationToken);

                var uDataSet = _mapper.Map<UnitDataSetDetailsDto>(unitDataSet);

                var vm = new UnitDataSetDetailsVm
                {
                    UnitDataSet = uDataSet
                };

                return vm;
            }
        }
    }
}
