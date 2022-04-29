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

namespace Presentation.Application.DataStructures.Commands.UpdateComponent
{
    public class UpdateComponentCommand : AbstractRequest, IRequest<Unit>
    {
        public long ComponentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long DataStructureId { get; set; }
        public List<long> Records { get; set; }

        public class Handler : IRequestHandler<UpdateComponentCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateComponentCommand request, CancellationToken cancellationToken)
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

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
      
    }
}