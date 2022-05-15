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

namespace Presentation.Application.DataSets.DimensionalDataSet.Queries.GetDimensionalDataSetDetails
{
    public class GetDimensionalDataSetDetailsQuery : AbstractRequest, IRequest<DimensionalDataSetDetailsVm>
    {
         public long Id { get; set; }

        public class GetDimensionalDataSetDetailsQueryHandler : IRequestHandler<GetDimensionalDataSetDetailsQuery, DimensionalDataSetDetailsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetDimensionalDataSetDetailsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DimensionalDataSetDetailsVm> Handle(GetDimensionalDataSetDetailsQuery request, CancellationToken cancellationToken)
            {
                var dataSet = await _context.DataSets
                        .Where(ds => ds.Id == request.Id)
                        .AsNoTrackingWithIdentityResolution()
                        .ProjectTo<DimensionalDataSetDetailsDto>(_mapper.ConfigurationProvider,
                                                                 new Dictionary<string, object> { ["language"] = request.Language })
                        .SingleOrDefaultAsync(cancellationToken);
                var vm = new DimensionalDataSetDetailsVm
                {
                    DimensionalDataSet = dataSet
                };

                return vm;
            }
        }
    }
}
