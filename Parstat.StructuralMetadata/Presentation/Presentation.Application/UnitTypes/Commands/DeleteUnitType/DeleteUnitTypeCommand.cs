using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.UnitTypes.Commands.DeleteUnitType
{
    public class DeleteUnitTypeCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }

        public class Handler : IRequestHandler<DeleteUnitTypeCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUnitTypeCommand request, CancellationToken cancellationToken)
            {
                var unitType = await _context.UnitTypes.FirstOrDefaultAsync(ut => ut.Id == request.Id);              

                if (unitType != null)
                {
                    _context.UnitTypes.Remove(unitType);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }
        }
    }
}
