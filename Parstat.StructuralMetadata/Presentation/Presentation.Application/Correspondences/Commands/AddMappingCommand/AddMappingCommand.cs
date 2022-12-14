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
                                                                     //.Include(c => c.Mappings)
                                                                     .SingleOrDefaultAsync();
                
                if (correspondence == null) 
                {
                    throw new NotFoundException(nameof(Correspondence), request.CorrespondenceId);
                }

                var sourceNode = getSourceNode(correspondence, request);
                var targetNode = getTargetNode(correspondence, request);

                Mapping mapping = await _context.Mappings.Where(m => m.Source == sourceNode 
                                                                     && m.Target == targetNode
                                                                     && m.Correspondence == correspondence).FirstOrDefaultAsync();
                
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
                
                var sourceNode = _context.Nodes.FirstOrDefault((x) => x.Id == request.SourceId 
                                                                && x.NodeSetId == correspondence.SourceId);
               
                if (sourceNode == null) 
                {
                    throw new NotFoundException(nameof(Node), request.SourceId);
                }

                return sourceNode;
            }

            private Node getTargetNode(Correspondence correspondence, AddMappingCommand request) 
            {
                var targetNode = _context.Nodes.FirstOrDefault((x) => x.Id == request.TargetId 
                                                                    && x.NodeSetId == correspondence.TargetId);
                
                if (targetNode== null) 
                {
                    throw new NotFoundException(nameof(Node), request.TargetId);
                }

                return targetNode;
            }
        }
    }
}