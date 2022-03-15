using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.ValueDomains.Commands.UpdateValueDomain
{
    public class UpdateValueDomainCommand : AbstractRequest, IRequest<Unit>
    {
        public long Id { get; set; }

        public string LocalId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ValueDomainType Type { get; set; }

        public ValueDomainScope Scope { get; set; }

        public string Expression { get; set; }

        public DataType DataType { get; set; }

        public long? MeasurementUnitId { get; set; }

        public long? NodesetId { get; set; }

        public long? LevelId { get; set; }

        public string Version { get; set; } = "1.0";

        public DateTime VersionDate { get; set; } = DateTime.Now;

        public string VersionRationale { get; set; } = "First Version";


        public class Handler : IRequestHandler<UpdateValueDomainCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateValueDomainCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);

                var valueDomain = await _context.ValueDomains
                        .FirstOrDefaultAsync(ut => ut.Id == request.Id);
                if (valueDomain == null)
                    throw new NotFoundException(nameof(ValueDomains), request.Id);

                if (request.MeasurementUnitId.HasValue)
                {
                    var measurementUnit = await _context.MeasurementUnits
                        .FirstOrDefaultAsync(ut => ut.Id == request.MeasurementUnitId);
                    if (measurementUnit == null)
                        throw new NotFoundException(nameof(MeasurementUnit), request.MeasurementUnitId);
                }

                if (request.LevelId.HasValue)
                {
                    var level = await _context.Levels
                    .FirstOrDefaultAsync(ut => ut.Id == request.LevelId);
                    if (level == null)
                        throw new NotFoundException(nameof(Level), request.LevelId);
                }

                if (request.NodesetId.HasValue)
                {
                    var nodeSet = await _context.NodeSets
                    .FirstOrDefaultAsync(ut => ut.Id == request.NodesetId);
                    if (nodeSet == null)
                        throw new NotFoundException(nameof(NodeSet), request.NodesetId);
                }

                valueDomain.LevelId = request.LevelId;
                valueDomain.NodeSetId = request.NodesetId;
                valueDomain.Type = request.Type;
                valueDomain.Name.AddText(language, request.Name);
                valueDomain.Scope = request.Scope;
                valueDomain.MeasurementUnitId = request.MeasurementUnitId;
                valueDomain.Description.AddText(language, request.Description);
                valueDomain.Version = request.Version;
                valueDomain.VersionDate = request.VersionDate;

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
