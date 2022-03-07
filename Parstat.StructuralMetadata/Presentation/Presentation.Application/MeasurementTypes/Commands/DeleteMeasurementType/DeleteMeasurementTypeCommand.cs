using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.MeasurementTypes.Commands.DeleteMeasurementType
{
    public class DeleteMeasurementTypeCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }

        public class Handler : IRequestHandler<DeleteMeasurementTypeCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteMeasurementTypeCommand request, CancellationToken cancellationToken)
            {               
                var entity = await _context.MeasurementTypes
                    .FirstOrDefaultAsync(mt => mt.Id == request.Id);
               
               if(entity != null)
                {
                    _context.MeasurementTypes.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);                
                }
 
                return Unit.Value;
            }
        }
    }
}
