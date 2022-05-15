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

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateCommand
{
    public class UpdateUnitDataStructureCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime? VersionDate { get; set; }
        public string VersionRationale { get; set; }
        public string Group { get; set; }

        public class Handler : IRequestHandler<UpdateUnitDataStructureCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUnitDataStructureCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);

                var entity = await _context.DataStructures.SingleOrDefaultAsync(ds => ds.Id == request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(DataStructure), request.Id);
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

                entity.Group = request.Group;

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
