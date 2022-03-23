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

        public ValueDomainType? Type { get; set; }

        public ValueDomainScope? Scope { get; set; }

        public string Expression { get; set; }

        public DataType? DataType { get; set; }

        public long? MeasurementUnitId { get; set; }

        public long? NodesetId { get; set; }

        public long? LevelId { get; set; }

        public string Version { get; set; }

        public DateTime? VersionDate { get; set; }

        public string VersionRationale { get; set; }


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
                {
                    throw new NotFoundException(nameof(ValueDomains), request.Id);
                }
                updateMeasurmentUnit(valueDomain, request.MeasurementUnitId.Value);
                updateLevel(valueDomain, request.LevelId.Value);
                updateNodeSet(valueDomain, request.NodesetId.Value);
                valueDomain.Name.AddText(language, request.Name);
                valueDomain.Description.AddText(language, request.Description);

                if(request.Type.HasValue)
                {
                    valueDomain.Type = request.Type.Value;
                }

                if(request.Scope.HasValue)
                {
                    valueDomain.Scope = request.Scope.Value;
                }
                
                if(!String.IsNullOrWhiteSpace(request.Version)) 
                {
                    valueDomain.Version = request.Version;
                }

                if(request.VersionDate.HasValue)
                {
                    valueDomain.VersionDate = request.VersionDate.Value;
                }

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }

            private async void updateMeasurmentUnit(ValueDomain valueDomain, long? measurementUnitId) {
                if(measurementUnitId.HasValue)
                {
                    var measurementUnit = await _context.MeasurementUnits
                        .FirstOrDefaultAsync(mu => mu.Id == measurementUnitId.Value);
                    if(measurementUnit != null)
                    {
                        valueDomain.MeasurementUnit = measurementUnit;
                    }
                     else
                    {
                        throw new NotFoundException(nameof(MeasurementUnit), measurementUnitId.Value);
                    }
                }
               
            }

            private async void updateLevel(ValueDomain valueDomain, long? levelId) {
                if(levelId.HasValue)
                {
                    var level = await _context.Levels.FirstOrDefaultAsync(l => l.Id == levelId.Value);
                    if(level != null)
                    {
                        valueDomain.Level = level;
                    }
                    else
                    {
                        throw new NotFoundException(nameof(Level), levelId.Value);
                    }
                }
            }

            
            private async void updateNodeSet(ValueDomain valueDomain, long? nodeSetId) {
                if(nodeSetId.HasValue)
                {
                    var nodeSet = await _context.NodeSets.FirstOrDefaultAsync(ns => ns.Id == nodeSetId.Value);
                    if(nodeSet != null)
                    {
                        valueDomain.NodeSet = nodeSet;
                    }
                    else {
                        throw new NotFoundException(nameof(NodeSet), nodeSetId.Value);
                    }
                }
            }
        }
    }
}
