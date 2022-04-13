using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.Correspondences.Commands.DeleteCommand
{
    public class DeleteCorrespondenceCommand : AbstractRequest, IRequest<Unit>
    {
        public long Id { get; set; }

        public class Handler : IRequestHandler<DeleteCorrespondenceCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCorrespondenceCommand request, CancellationToken cancellationToken)
            {               
                var entity = await _context.Correspondences
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
               
                if(entity != null)
                {
                    _context.Correspondences.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);                
                }
 
                return Unit.Value;
            }
        }
    }
}
