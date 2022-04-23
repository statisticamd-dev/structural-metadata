using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.UpdateCommand
{
    public class UpdateUnitDataSetCommand : AbstractRequest, IRequest
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

        public class Handler : IRequestHandler<UpdateUnitDataSetCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUnitDataSetCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse<Language>(request.Language, true, out Language language);

                var entity = await _context.DataSets.SingleOrDefaultAsync(ns => ns.StatisticalProgramId == request.StatisticalProgramId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(DataSet), request.StructureId);
                }

                entity.Name.AddText(language, request.Name);
                entity.Description.AddText(language, request.Description);
                entity.VersionRationale.AddText(language, request.VersionRationale);
                if (!string.IsNullOrWhiteSpace(request.Version))
                {
                    entity.Version = request.Version;
                }
                entity.VersionDate = request.VersionDate;

                entity.ExchangeChannel = request.ExchangeChannel;
                entity.ExchangeDirection = request.ExchangeDirection;
                entity.ReportingBegin = request.ReportingBegin;
                entity.ReportingEnd = request.ReportingEnd;
                entity.Connection = request.Connection;
                entity.FilterExpression = request.FilterExpression;


                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
