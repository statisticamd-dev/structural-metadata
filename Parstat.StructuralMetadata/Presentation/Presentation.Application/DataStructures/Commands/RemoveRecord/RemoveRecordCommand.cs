using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataStructures.Commands.RemoveRecord
{
    public class RemoveRecordCommand : AbstractRequest, IRequest<Unit>
    {
        public long DataStructureId { get; set; }
        public long RecordId { get; set; }

        public class Handler : IRequestHandler<RemoveRecordCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(RemoveRecordCommand request, CancellationToken cancellationToken)
            {
                //var entity = await _context.LogicalRecords.SingleOrDefaultAsync(lr => lr.Id == request.RecordId );
                var entity = await _context.LogicalRecords.SingleOrDefaultAsync(lr => (lr.DataStructureId == request.DataStructureId && lr.Id == request.RecordId ));

                if (entity != null)
                {
                    _context.LogicalRecords.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);
                return Unit.Value;
            }
        }
    }
}