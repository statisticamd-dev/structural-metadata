using MediatR;
using System;
using Presentation.Application.Common.Requests;
using Presentation.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using Presentation.Domain;

namespace Presentation.Application.MeasurementTypes.Commands
{
    public class CreateMeasurementTypeCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
        public string VersionRationale { get; set; }

         public class Handler : IRequestHandler<CreateMeasurementTypeCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(CreateMeasurementTypeCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var entity = new MeasurementType 
                {
                      LocalId = request.LocalId,
                      Name = MultilanguageString.Init(language, request.Name),
                      Description = request.Description != null ? MultilanguageString.Init(language, request.Description) : null,
                      Version = request.Version != null ? request.Version : "1.0",
                      VersionDate = request.VersionDate != null ? request.VersionDate : DateTime.Now,
                      VersionRationale = request.VersionRationale != null ? MultilanguageString.Init(language, request.VersionRationale) : null,
                };
                _context.MeasurementTypes.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return entity.Id;
            }

        }
    }
}