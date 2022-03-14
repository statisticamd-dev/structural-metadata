using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.ValueDomains.Commands.CreteValueDomain
{
    public class CreateValueDomainCommand : AbstractRequest, IRequest<long>
    {
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

        public class Handler : IRequestHandler<CreateValueDomainCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateValueDomainCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);

                var measurementUnit = await _context.MeasurementUnits
                    .FirstOrDefaultAsync(ut => ut.Id == request.MeasurementUnitId);
                if (measurementUnit == null)
                    throw new NotFoundException(nameof(MeasurementUnit), request.MeasurementUnitId);

                var level = await _context.Levels
                   .FirstOrDefaultAsync(ut => ut.Id == request.LevelId);
                if (level == null)
                    throw new NotFoundException(nameof(Level), request.LevelId);

                var nodeSet = await _context.NodeSets
                   .FirstOrDefaultAsync(ut => ut.Id == request.NodesetId);
                if (nodeSet == null)
                    throw new NotFoundException(nameof(NodeSet), request.NodesetId);

                var newValueDomain = new ValueDomain()
                {
                    LevelId = request.LevelId,
                    NodeSetId = request.NodesetId,
                    Type = request.Type,
                    Name = MultilanguageString.Init(language, request.Name),
                    Scope = request.Scope,
                    MeasurementUnitId = request.MeasurementUnitId,
                    Description = MultilanguageString.Init(language, request.Description),
                    Version = request.Version,
                    VersionDate = request.VersionDate,
                };

                var response = _context.ValueDomains.Add(newValueDomain);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return response.Entity.Id;
            }
        }
    }
}