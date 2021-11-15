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

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class GetRepresentedVariableQuery : AbstractRequest, IRequest<RepresentedVariableVm>
    {
        public long Id { get; set; }

        public class GetRepresentedVariableQueryHandler : IRequestHandler<GetRepresentedVariableQuery, RepresentedVariableVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetRepresentedVariableQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RepresentedVariableVm> Handle(GetRepresentedVariableQuery request, CancellationToken cancellationToken)
            {
                var representedVariable = await _context.RepresentedVariables
                    .Where(rv => rv.Id == request.Id)
                    //.Include(rv => rv.SentinelValueDomain)
                    //    .ThenInclude(svd => svd.NodeSet)
                    //        .ThenInclude(ns => ns.Nodes)
                    //.Include(rv => rv.SubstantiveValueDomain.Level.NodeSet.Nodes)
                    .Include(rv => rv.SubstantiveValueDomain)
                        .ThenInclude(svd => svd.NodeSet)
                            .ThenInclude(ns => ns.Nodes)
                    .AsNoTracking()
                    .ProjectTo<RepresentedVariableDetailsDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .SingleOrDefaultAsync(cancellationToken);

                var vm = new RepresentedVariableVm
                {
                    RepresentedVariable = representedVariable
                };

                return vm;
            }
        }
    }
}