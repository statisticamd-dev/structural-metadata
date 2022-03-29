using MediatR;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.Correspondences.Commands.CreateCommand
{
    public class CreateCorrespondenceCommand : AbstractRequest, IRequest<long>
    {
        public long SourceId { get; set; }

        public long TargetId { get; set; }

        public Relationship Relationship { get; set; }

        public class Handler : IRequestHandler<CreateCorrespondenceCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateCorrespondenceCommand request, CancellationToken cancellationToken)
            {
                var sourceNodeSet = _context.NodeSets.FirstOrDefault((x) => x.Id == request.SourceId);
                if (sourceNodeSet == null) 
                {
                    throw new NotFoundException(nameof(NodeSet), request.SourceId);
                }

                var targetNodeSet = _context.NodeSets.FirstOrDefault((x) => x.Id == request.TargetId);
                if (targetNodeSet == null)
                {
                    throw new NotFoundException(nameof(NodeSet), request.TargetId);
                } 

                Correspondence correspondence = null;
                
                correspondence = _context.Correspondences.Where(c => (c.Source == sourceNodeSet && c.Target == targetNodeSet) 
                                                                            || (c.Source == targetNodeSet && c.Target == sourceNodeSet)).FirstOrDefault();
                if (correspondence == null) {
                    correspondence = new Correspondence
                    {
                        Source = sourceNodeSet,
                        Target = targetNodeSet,
                        Relationship = request.Relationship
                    };
                     _context.Correspondences.Add(correspondence);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return correspondence.Id;
            }
        }
    }
}
