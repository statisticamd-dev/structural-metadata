using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataSets.DataStructures.Commands.DeleteCommand
{
    public class DeleteDataStructureCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }
        public class Handler : IRequestHandler<DeleteDataStructureCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteDataStructureCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.DataStructures.SingleOrDefaultAsync(ds => ds.Id == request.Id);

                if (entity != null)
                {
                    _context.DataStructures.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
