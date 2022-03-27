using MediatR;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.Correspondences.Commands.AddMappingCommand
{
    public class AddMappingCommand : AbstractRequest, IRequest<long>
    {
        public long CorrespondenceId { get; set; }

        public long SourceId { get; set; }

        public long TargetId { get; set; }

        public class Handler : IRequestHandler<AddMappingCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(AddMappingCommand request, CancellationToken cancellationToken)
            {
                var correspondenceFound = _context.Correspondences.FirstOrDefault((x) => x.Id == request.CorrespondenceId);
                if (correspondenceFound == null) throw new NotFoundException(nameof(Correspondence), request.CorrespondenceId);

                var sourceNodeFound = correspondenceFound.Source.Nodes.FirstOrDefault((x) => x.Id == request.SourceId);
                if (sourceNodeFound == null) throw new NotFoundException(nameof(Node), request.SourceId);

                var targetNodeFound = correspondenceFound.Target.Nodes.FirstOrDefault((x) => x.Id == request.TargetId);
                if (targetNodeFound == null) throw new NotFoundException(nameof(Node), request.TargetId);

                var newMap = new Mapping
                {
                    Target = targetNodeFound,
                    TargetId = targetNodeFound.Id,
                    Source = sourceNodeFound,
                    SourceId = sourceNodeFound.Id,
                    Correspondence = correspondenceFound,
                    CorrespondenceId = correspondenceFound.Id
                };

                correspondenceFound.Mappings.Add(newMap);
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return newMap.Id;
            }
        }
    }
}
