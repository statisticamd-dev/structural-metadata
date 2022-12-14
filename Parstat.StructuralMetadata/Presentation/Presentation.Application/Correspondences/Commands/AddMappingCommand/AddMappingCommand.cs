using MediatR;
using Microsoft.EntityFrameworkCore;
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
                 var correspondence =  await _context.Correspondences.Where(c => c.Id == request.CorrespondenceId)
                                                                     /*.Include(c => c.Source)
                                                                     .Include(c => c.Target)
                                                                     .Include(c => c.Source.Nodes)
                                                                     .Include(c => c.Target.Nodes)*/
                                                                     .SingleOrDefaultAsync();
                
                if (correspondence == null) 
                {
                    throw new NotFoundException(nameof(Correspondence), request.CorrespondenceId);
                }

                var sourceNode = getSourceNode(correspondence, request);
                var targetNode = getTargetNode(correspondence, request);

                Mapping mapping = correspondence.Mappings.Where(m => m.Source == sourceNode 
                                                                     && m.Target == targetNode).FirstOrDefault();
                
                if(mapping == null) 
                {
                    //save new mapping if not exist
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

                return correspondence.Id;
            }

            private Node getSourceNode( Correspondence correspondence, AddMappingCommand request)
            {
                var sourceNode = _context.Nodes.FirstOrDefault(x => x.NodeSetId == correspondence.SourceId && x.Id == request.SourceId);
                //var sourceNode = correspondence.Source.Nodes.FirstOrDefault((x) => x.Id == request.SourceId);
               
                if (sourceNode == null) 
                {
                    throw new NotFoundException(nameof(Node), request.SourceId);
                }

                return sourceNode;
            }

            private Node getTargetNode(Correspondence correspondence, AddMappingCommand request) 
            {
                var targetNode = _context.Nodes.FirstOrDefault(x => x.NodeSetId == correspondence.TargetId && x.Id == request.TargetId);
                //var targetNode = correspondence.Target.Nodes.FirstOrDefault((x) => x.Id == request.TargetId);
                
                if (targetNode== null) 
                {
                    throw new NotFoundException(nameof(Node), request.TargetId);
                }

                return targetNode;
            }
        }
    }
}
