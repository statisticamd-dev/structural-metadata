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
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Labels.Queries.GetLabes
{
    public class GetLabelsQuery : AbstractRequest, IRequest<LabelsVm>
    {
        public string Value { get; set; }

        public class GetLabelsQueryHandler : IRequestHandler<GetLabelsQuery, LabelsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetLabelsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LabelsVm> Handle(GetLabelsQuery request, CancellationToken cancellationToken)
            {
                IList<LabelDto> labels;
                if(string.IsNullOrEmpty(request.Value))
                {
                labels = await _context.Labels
                    .AsNoTracking()
                    .ProjectTo<LabelDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(mu => mu.Id)
                    .ToListAsync(cancellationToken);
                } 
                else 
                {
                    labels = await _context.Labels
                        .AsNoTracking()
                        .Where(l => (l.Value.En.Contains(request.Value) || l.Value.Ro.Contains(request.Value) || l.Value.Ru.Contains(request.Value)))
                        .ProjectTo<LabelDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                        .OrderBy(mu => mu.Id)
                        .ToListAsync(cancellationToken);
                }

                var vm = new LabelsVm
                {
                    Labels = labels
                };

                return vm;
            }
        }
    }
}