using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataStructures.Commands.RemoveComponent
{
    public class RemoveComponentCommand : AbstractRequest, IRequest<Unit>
    {
        public long DataStructureId { get; set; }
        public long ComponentId { get; set; }

        public class Handler : IRequestHandler<RemoveComponentCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(RemoveComponentCommand request, CancellationToken cancellationToken)
            {
                //var entity = await _context.Components.SingleOrDefaultAsync(cm => cm.Id == request.ComponentId);
                var entity = await _context.Components.SingleOrDefaultAsync(cm => (cm.DataStructureId == request.DataStructureId && cm.Id == request.ComponentId));

                if (entity != null)
                {
                    _context.Components.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);
                return Unit.Value;
            }
        }
    }
}