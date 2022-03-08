using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.Concepts.Commands.DeleteConcept
{
    public class DeleteConceptCommand : AbstractRequest, IRequest<Unit>
    {
        public long Id { get; set; }

        public class Handler : IRequestHandler<DeleteConceptCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteConceptCommand request, CancellationToken cancellationToken)
            {               
                var entity = await _context.Concepts
                    .FirstOrDefaultAsync(mt => mt.Id == request.Id);
               
                if(entity != null)
                {
                    _context.Concepts.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);                
                }
 
                return Unit.Value;
            }
        }
    }
}
