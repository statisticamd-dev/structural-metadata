using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.UpdateCommand
{
    public class UpdateUnitDataSetCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }
        public long StructureId { get; set; }
        public long StatisticalProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime? VersionDate { get; set; }
        public string VersionRationale { get; set; }
        public ExchangeChannel ExchangeChannel { get; set; }
        public ExchangeDirection ExchangeDirection { get; set; }
        public DateTime? ReportingBegin { get; set; }
        public DateTime? ReportingEnd { get; set; }
        public string Connection { get; set; }
        public string FilterExpression { get; set; }

        public class Handler : IRequestHandler<UpdateUnitDataSetCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUnitDataSetCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);

                var entity = await _context.DataSets.SingleOrDefaultAsync(ds => ds.Id == request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(DataSet), request.Id);
                }

                entity.Name.AddText(language, request.Name);
                entity.Description.AddText(language, request.Description);
                entity.VersionRationale.AddText(language, request.VersionRationale);

                if (!string.IsNullOrWhiteSpace(request.Version))
                {
                    entity.Version = request.Version;
                }
                if (request.VersionDate.HasValue)
                {
                    entity.VersionDate = request.VersionDate.Value;
                }

                entity.ExchangeChannel = request.ExchangeChannel;
                entity.ExchangeDirection = request.ExchangeDirection;
                entity.ReportingBegin = request.ReportingBegin;
                entity.ReportingEnd = request.ReportingEnd;
                entity.Connection = request.Connection;
                entity.FilterExpression = request.FilterExpression;
                entity.StatisticalProgramId = request.StatisticalProgramId;

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
