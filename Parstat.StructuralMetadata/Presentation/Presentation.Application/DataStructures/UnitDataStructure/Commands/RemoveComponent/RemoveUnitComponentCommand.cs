using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.RemoveComponent
{
    public class RemoveUnitComponentCommand : AbstractRequest, IRequest<Unit>
    {
        public long UnitDataStructureId { get; set; }
        public long UnitComponentId { get; set; }

        public class Handler : IRequestHandler<RemoveUnitComponentCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(RemoveUnitComponentCommand request, CancellationToken cancellationToken)
            {
                //var entity = await _context.Components.SingleOrDefaultAsync(cm => cm.Id == request.ComponentId);
                var entity = await _context.Components.SingleOrDefaultAsync(cm => (cm.DataStructureId == request.UnitDataStructureId && cm.Id == request.UnitComponentId));

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