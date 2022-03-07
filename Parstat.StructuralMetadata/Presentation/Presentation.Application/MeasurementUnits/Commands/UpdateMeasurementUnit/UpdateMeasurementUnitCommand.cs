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

namespace Presentation.Application.MeasurementUnits.Commands.UpdateMeasurementUnit
{
    public class UpdateMeasurementUnitCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime? VersionDate { get; set; }
        public string VersionRationale { get; set; }
        public string Abbreviation { get; set; }
        public Boolean? IsStandard { get; set; }
        public string ConvertionRule { get; set; }
        public long MeasurementTypeId { get; set; }


        public class Handler : IRequestHandler<UpdateMeasurementUnitCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateMeasurementUnitCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
               
                var entity = await _context.MeasurementUnits.SingleOrDefaultAsync(mu => mu.Id == request.Id);

                if(entity == null) 
                {
                    throw new NotFoundException(nameof(MeasurementUnit), request.Id);
                }
                entity.Name.AddText(language, request.Name);
                entity.Description.AddText(language, request.Description);
                entity.VersionRationale.AddText(language, request.VersionRationale);
                if(request.IsStandard.HasValue) {
                    entity.IsStandard = request.IsStandard.Value;
                }
                if(!String.IsNullOrEmpty(request.Abbreviation)) {
                    entity.Abbreviation = request.Abbreviation;
                }
                if(!String.IsNullOrEmpty(request.ConvertionRule)) {
                    entity.ConvertionRule = request.ConvertionRule;
                }
                if(!String.IsNullOrEmpty(request.Version)) {
                    entity.Version = request.Version;
                }
                
                if(request.VersionDate.HasValue) {
                    entity.VersionDate = request.VersionDate.Value;
                }

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }

        }
    }
}
