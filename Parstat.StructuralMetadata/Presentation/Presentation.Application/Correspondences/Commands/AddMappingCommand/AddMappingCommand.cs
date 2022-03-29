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
                var correspondence = _context.Correspondences.FirstOrDefault((x) => x.Id == request.CorrespondenceId);
                if (correspondence == null) 
                {
                    throw new NotFoundException(nameof(Correspondence), request.CorrespondenceId);
                }

                var sourceNode = correspondence.Source.Nodes.FirstOrDefault((x) => x.Id == request.SourceId);
                if (sourceNode == null) 
                {
                    throw new NotFoundException(nameof(Node), request.SourceId);
                }

                var targetNode = correspondence.Target.Nodes.FirstOrDefault((x) => x.Id == request.TargetId);
                if (targetNode== null) 
                {
                    throw new NotFoundException(nameof(Node), request.TargetId);
                }
                
                Mapping mapping = correspondence.Mappings.Where(m => m.Source == sourceNode && m.Target == targetNode).FirstOrDefault();
                
                if(mapping == null) 
                {
                    mapping = new Mapping
                    {
                        Target = targetNode,
                        Source = sourceNode,
                        Correspondence = correspondence,
                    };

                    correspondence.Mappings.Add(mapping);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return mapping.Id;
            }
        }
    }
}
