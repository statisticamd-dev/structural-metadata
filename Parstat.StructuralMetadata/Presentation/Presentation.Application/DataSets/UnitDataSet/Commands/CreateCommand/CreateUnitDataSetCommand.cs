using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand
{
    public class CreateUnitDataSetCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public long StructureId { get; set; }
        public long StatisticalProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";
        public ExchangeChannel ExchangeChannel { get; set; }
        public ExchangeDirection ExchangeDirection { get; set; }
        public DateTime ReportingBegin { get; set; } = DateTime.MinValue;
        public DateTime ReportingEnd { get; set; } = DateTime.MinValue;
        public string Connection { get; set; }
        public string FilterExpression { get; set; }

        public class Handler : IRequestHandler<CreateUnitDataSetCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUnitDataSetCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);

                var unitDataSetEntity = new DataSet
                {
                    Connection = request.Connection,
                    ExchangeChannel = request.ExchangeChannel,
                    FilterExpression = request.FilterExpression,
                    Description = MultilanguageString.Init(language, request.Description),
                    ExchangeDirection = request.ExchangeDirection,
                    LocalId = request.LocalId,
                    Name = MultilanguageString.Init(language, request.Name),
                    ReportingBegin = request.ReportingBegin,
                    ReportingEnd = request.ReportingEnd,
                    StructureId = request.StructureId,
                    Version = request.Version,
                    StatisticalProgramId = request.StatisticalProgramId,
                    VersionRationale = MultilanguageString.Init(language, request.VersionRationale),
                    VersionDate = request.VersionDate
                };

                _context.DataSets.Add(unitDataSetEntity);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return unitDataSetEntity.Id;
            }
        }
    }
}
