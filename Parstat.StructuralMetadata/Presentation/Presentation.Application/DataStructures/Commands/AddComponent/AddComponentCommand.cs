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

namespace Presentation.Application.DataStructures.Commands.AddComponent
{
    public class AddComponentCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long DataStructureId { get; set; }
        public List<long> Records { get; set; }

        public class Handler : IRequestHandler<AddComponentCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(AddComponentCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);
                var dataStructure = await _context.DataStructures.FindAsync(request.DataStructureId, cancellationToken);
                if(dataStructure == null)
                {
                    throw new NotFoundException(nameof(DataStructure), request.DataStructureId);
                }
                var records = dataStructure.LogicalRecords
                        .Where(lr =>request.Records.Contains(lr.Id) ).ToList();
                        
                var component = new Component 
                {
                    LocalId = request.LocalId,
                    Name = MultilanguageString.Init(language, request.Name),
                    Description = MultilanguageString.Init(language, request.Description),
                    DataStructureId = request.DataStructureId,
                    Records = records,
                };

                  _context.Components.Add(component);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return component.Id;
            }

        }
    }
}