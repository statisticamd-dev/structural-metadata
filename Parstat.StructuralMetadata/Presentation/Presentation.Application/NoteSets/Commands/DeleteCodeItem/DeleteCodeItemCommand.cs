using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.NoteSets.Commands.DeleteCodeItem
{
    public class DeleteCodeItemCommand : AbstractRequest, IRequest<Unit>
    {
        public long NodeSetId { get; set; }
        public string Code { get; set; }
        public class Handler : IRequestHandler<DeleteCodeItemCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCodeItemCommand request, CancellationToken cancellationToken)
            {
                var node = await _context.Nodes
                    .FirstOrDefaultAsync(ut => ut.NodeSetId == request.NodeSetId && ut.Code == request.Code);

                if (node != null)
                {
                    _context.Nodes.Remove(node);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }
        }
    }
}