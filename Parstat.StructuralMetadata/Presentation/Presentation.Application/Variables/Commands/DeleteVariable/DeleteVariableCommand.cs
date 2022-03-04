using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;

namespace Presentation.Application.Variables.Commands.DeleteVariable
{
    public class DeleteVariableCommand :  AbstractRequest, IRequest<Unit>
    {
        public long Id { get; set; }
        public class Handler : IRequestHandler<DeleteVariableCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteVariableCommand request, CancellationToken cancellationToken)
            {               
                var variable = await _context.Variables
                    .FirstOrDefaultAsync(ut => ut.Id == request.Id);
               
               if(variable != null)
                {
                    _context.Variables.Remove(variable);
                    await _context.SaveChangesAsync(cancellationToken);                
                }
 
                return Unit.Value;
            }
        }
    }
}