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

namespace Presentation.Application.DataSets.DimensionalDataSet.Queries.GetDimensionalDataSet
{
    public class GetDimensionalDataSetQuery : AbstractRequest, IRequest<DimensionalDataSetVm>
    {
        public long Id { get; set; }

        public class GetDimensionalDataSetQueryHandler : IRequestHandler<GetDimensionalDataSetQuery, DimensionalDataSetVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetDimensionalDataSetQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DimensionalDataSetVm> Handle(GetDimensionalDataSetQuery request, CancellationToken cancellationToken)
            {
                var dataSet = await _context.DataSets
                        .Where(ds => ds.Id == request.Id)
                        .AsNoTrackingWithIdentityResolution()
                        .ProjectTo<DimensionalDataSetDto>(_mapper.ConfigurationProvider,
                                                                 new Dictionary<string, object> { ["language"] = request.Language })
                        .SingleOrDefaultAsync(cancellationToken);
                var vm = new DimensionalDataSetVm
                {
                    DimensionalDataSet = dataSet
                };

                return vm;
            }
        }
        
    }
}
