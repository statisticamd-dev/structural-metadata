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
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateComponent
{
    public class UpdateUnitComponentCommand : AbstractRequest, IRequest<Unit>
    {
        public long ComponentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ComponentType Type { get; set; }
        public Boolean? IsIdentifierComposite { get; set; }
        public Boolean? IsIdentifierUnique { get; set; }
        public IdentifierRole? IdentifierRole { get; set; }
        public Boolean? IsAttributeMandatory { get; set; }
        public AttributeAttachmentLevel? AttributeAttachmentLevel { get; set; }
        public long DataStructureId { get; set; }
        public List<long> Records { get; set; }

        public class Handler : IRequestHandler<UpdateUnitComponentCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUnitComponentCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);

                var entity = await _context.Components
                        .SingleOrDefaultAsync(c => c.Id == request.ComponentId && c.DataStructureId == request.DataStructureId);

                var records = await _context.LogicalRecords
                        .Where(lr => lr.DataStructureId == request.DataStructureId && request.Records.Contains(lr.Id))
                        .ToListAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(DataStructure), request.ComponentId);
                }

                entity.Name.AddText(language, request.Name);
                entity.Description.AddText(language, request.Description);
                entity.Records = records;
                entity.Type = request.Type;
                entity.AttributeAttachmentLevel = request.AttributeAttachmentLevel;
                entity.IsAttributeMandatory = request.IsAttributeMandatory;
                entity.IsIdentifierComposite = request.IsIdentifierComposite;
                entity.IsIdentifierUnique = request.IsIdentifierUnique;
                entity.IdentifierRole = request.IdentifierRole;

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
      
    }
}