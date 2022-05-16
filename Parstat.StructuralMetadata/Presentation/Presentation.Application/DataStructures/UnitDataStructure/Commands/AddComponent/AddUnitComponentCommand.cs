using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Application.Common.Exceptions;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.AddComponent
{
    public class AddUnitComponentCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public ComponentType Type { get; set; }
        public Boolean? IsIdentifierComposite { get; set; }
        public Boolean? IsIdentifierUnique { get; set; }
        public IdentifierRole? IdentifierRole { get; set; }
        public Boolean? IsAttributeMandatory { get; set; }
        public AttributeAttachmentLevel? AttributeAttachmentLevel { get; set; }
        public long DataStructureId { get; set; }
        public List<long> Records { get; set; }
        public long RepresentedVariableId { get; set; }

        public class Handler : IRequestHandler<AddUnitComponentCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(AddUnitComponentCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);
                
                var dataStructure =  await _context.DataStructures
                                        .Where(ds => ds.Id == request.DataStructureId)
                                        .Include(ds => ds.LogicalRecords)
                                        .FirstOrDefaultAsync();
                
                if(dataStructure == null)
                {
                    throw new NotFoundException(nameof(DataStructure), request.DataStructureId);
                }
                
                var component = new Component 
                {
                    LocalId = request.LocalId,
                    Version = request.Version,
                    Name = MultilanguageString.Init(language, request.Name),
                    Description = MultilanguageString.Init(language, request.Description),
                    DataStructureId = request.DataStructureId,
                    Type = request.Type,
                    IsIdentifierComposite = request.IsIdentifierComposite,
                    IsIdentifierUnique = request.IsIdentifierUnique,
                    IsAttributeMandatory = request.IsAttributeMandatory,
                    IdentifierRole = request.IdentifierRole,
                    AttributeAttachmentLevel = request.AttributeAttachmentLevel,
                    RepresentedVariableId = request.RepresentedVariableId,
                    Records = dataStructure.Type == DataSetType.UNIT ? dataStructure.LogicalRecords
                        .Where(lr => request.Records.Contains(lr.Id) ).ToList() : null
                };

                  _context.Components.Add(component);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return component.Id;
            }

        }
    }
}