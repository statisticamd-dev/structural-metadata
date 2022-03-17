using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.MeasurementUnits.Commands.DeleteMeasurementUnit
{
    public class DeleteCodeListCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }

        public class Handler : IRequestHandler<DeleteCodeListCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCodeListCommand request, CancellationToken cancellationToken)
            {                
                var entity = await _context.NodeSets.SingleOrDefaultAsync(mu => mu.Id == request.Id);

                if (entity != null)
                {
                    _context.NodeSets.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
