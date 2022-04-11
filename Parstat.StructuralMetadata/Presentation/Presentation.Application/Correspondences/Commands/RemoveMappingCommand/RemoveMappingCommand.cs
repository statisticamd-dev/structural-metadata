using MediatR;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.Correspondences.Commands.RemoveMappingCommand
{
    public class RemoveMappingCommand : AbstractRequest, IRequest<Unit>
    {
        public long MappingId { get; set; }

        public long CorrespondenceId { get; set; }

        public class Handler : IRequestHandler<RemoveMappingCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(RemoveMappingCommand request, CancellationToken cancellationToken)
            {
                var mapping = _context.Mappings.FirstOrDefault(m => m.Id == request.MappingId 
                                                                    && m.CorrespondenceId == request.CorrespondenceId);
                if (mapping != null)
                {
                    _context.Mappings.Remove(mapping);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
