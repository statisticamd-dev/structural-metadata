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

namespace Presentation.Application.UnitTypes.Queries.GetUnitTypes
{
    public class GetUnitTypesQuery : AbstractRequest, IRequest<UnitTypeListVm>
    {
        public class GetUnitTypesQueryHandler : IRequestHandler<GetUnitTypesQuery, UnitTypeListVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetUnitTypesQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UnitTypeListVm> Handle(GetUnitTypesQuery request, CancellationToken cancellationToken)
            {
                var unitTypes = await _context.UnitTypes
                    .AsNoTracking()
                    .ProjectTo<UnitTypeDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(v => v.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new UnitTypeListVm
                {
                    UnitTypes = unitTypes
                };

                return vm;
            }
        }
    }
}