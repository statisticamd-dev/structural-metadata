using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Application.MeasurementUnits.Commands.DeleteMeasurementUnit
{
    public class DeleteMeasurementUnitCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }

        public class Handler : IRequestHandler<DeleteMeasurementUnitCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteMeasurementUnitCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
               
                var entity = await _context.MeasurementUnits.SingleOrDefaultAsync(mu => mu.Id == request.Id);

                if(entity != null) {
                    _context.MeasurementUnits.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }

        }
    }
}
