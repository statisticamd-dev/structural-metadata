using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataStructures.Commands.AddRecord
{
    public class AddRecordCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";
        public long DataStructureId { get; set; }
        public long? ParentId { get; set; }

        public class Handler : IRequestHandler<AddRecordCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(AddRecordCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);

                var logicalRecord = new LogicalRecord
                {
                    LocalId = request.LocalId,
                    DataStructureId = request.DataStructureId,
                    ParentId = request.ParentId,
                    Name = MultilanguageString.Init(language, request.Name),
                    Description = MultilanguageString.Init(language, request.Description),
                    Version = request.Version,
                    VersionDate = request.VersionDate,
                    VersionRationale = MultilanguageString.Init(language, request.VersionRationale)
                };

                 _context.LogicalRecords.Add(logicalRecord);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return logicalRecord.Id;
            }
        }
    }
}