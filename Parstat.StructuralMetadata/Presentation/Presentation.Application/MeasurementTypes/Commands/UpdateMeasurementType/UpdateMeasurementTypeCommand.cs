using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.MeasurementTypes.Commands.UpdateMeasurementType
{
    public class UpdateMeasurementTypeCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
         public string Version { get; set; }
        public DateTime? VersionDate { get; set; }
        public string VersionRationale { get; set; }

        public class Handler : IRequestHandler<UpdateMeasurementTypeCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateMeasurementTypeCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
               
                var entity = await _context.MeasurementTypes.SingleOrDefaultAsync(mt => mt.Id == request.Id);

                if(entity == null) 
                {
                    throw new NotFoundException(nameof(MeasurementType), request.Id);
                }
                entity.Name.AddText(language, request.Name);
                entity.Description.AddText(language, request.Description);
                entity.VersionRationale.AddText(language, request.VersionRationale);
                if(!String.IsNullOrEmpty(request.Version)) {
                    entity.Version = request.Version;
                }
                
                if(request.VersionDate.HasValue) {
                    entity.VersionDate = request.VersionDate.Value;
                }
                _context.MeasurementTypes.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }

        }
        
    }
}
