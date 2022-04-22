using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.RepresentedVariables.Commands.DeleteCommand
{
    public class DeleteRepresentedVariableCommand : AbstractRequest, IRequest
    {
         public long Id { get; set; }
        
        public class Handler : IRequestHandler<DeleteRepresentedVariableCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteRepresentedVariableCommand request, CancellationToken cancellationToken)
            {               
                var representedVariable = await _context.RepresentedVariables
                    .FirstOrDefaultAsync(ut => ut.Id == request.Id);
               
               if(representedVariable != null)
                {
                    _context.RepresentedVariables.Remove(representedVariable);
                    await _context.SaveChangesAsync(cancellationToken);                
                }
 
                return Unit.Value;
            }
        }
    }
}
