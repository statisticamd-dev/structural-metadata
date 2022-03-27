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
                var sourceNodeSetFound = _context.NodeSets.FirstOrDefault((x) => x.Id == request.SourceId);
                if (sourceNodeSetFound == null) throw new NotFoundException(nameof(NodeSet), request.SourceId);

                var targetNodeSetFound = _context.NodeSets.FirstOrDefault((x) => x.Id == request.TargetId);
                if (targetNodeSetFound == null) throw new NotFoundException(nameof(NodeSet), request.TargetId);

                //Should we check if correspondence exists? If yes the below statement should be uncomented

                Correspondence correspondence = null;
                //correspondence = _context.Correspondences.Where((x) => x.SourceId == sourceNodeSetFound.Id && x.TargetId == targetNodeSetFound.Id).FirstOrDefault();
                //if (correspondence != null)
                //{
                //    correspondence.Source = sourceNodeSetFound;
                //    correspondence.SourceId = sourceNodeSetFound.Id;
                //    correspondence.Target = targetNodeSetFound;
                //    correspondence.TargetId = targetNodeSetFound.Id;
                //    correspondence.Relationship = request.Relationship;
                //}
                //else
                //{
                correspondence = new Correspondence
                {
                    Source = sourceNodeSetFound,
                    SourceId = sourceNodeSetFound.Id,
                    Target = targetNodeSetFound,
                    TargetId = targetNodeSetFound.Id,
                    Relationship = request.Relationship
                };

                _context.Correspondences.Add(correspondence);

                //}

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return correspondence.Id;
            }
        }
    }
}
