using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.MeasurementUnits.Commands.CreateMeasurementUnit
{
    public class CreateMeasurementUnitCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";
        public string Abbreviation { get; set; }
        public bool IsStandard { get; set; } = false;
        public string ConvertionRule { get; set; }
        public long? MeasurementTypeId { get; set; }

        public class Handler : IRequestHandler<CreateMeasurementUnitCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(CreateMeasurementUnitCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var entity = new MeasurementUnit 
                {
                      LocalId = request.LocalId,
                      Name = MultilanguageString.Init(language, request.Name),
                      Description = MultilanguageString.Init(language, request.Description),
                      Version = request.Version,
                      VersionDate = request.VersionDate,
                      VersionRationale = MultilanguageString.Init(language, request.VersionRationale),
                      ConvertionRule = request.ConvertionRule,
                      Abbreviation = request.Abbreviation,
                      IsStandard = request.IsStandard,
                      MeasurementTypeId = request.MeasurementTypeId
                };
                _context.MeasurementUnits.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return entity.Id;
            }

        }
    }
}