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

namespace Presentation.Application.DataSets.Queries.GetDataSets
{
    public class GetDataSetsQuery : AbstractRequest, IRequest<DataSetsVm>
    {
        
        public class GetLabelsQueryHandler : IRequestHandler<GetDataSetsQuery, DataSetsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetLabelsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DataSetsVm> Handle(GetDataSetsQuery request, CancellationToken cancellationToken)
            {
                
                var datasets = await _context.DataSets
                    .AsNoTracking()
                    .ProjectTo<DataSetDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(mu => mu.Id)
                    .ToListAsync(cancellationToken);

                var vm = new DataSetsVm
                {
                    DataSets = datasets
                };

                return vm;
            }
        }
    }
}
