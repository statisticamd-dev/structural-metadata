using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.NodeSets.CodeLists.Commands.UpdateCommand
{
    public class UpdateCodeListCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime? VersionDate { get; set; }
        public string VersionRationale { get; set; }
        public bool IsSentinel { get; set; }

        public class Handler : IRequestHandler<UpdateCodeListCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCodeListCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var entity = await _context.NodeSets.SingleOrDefaultAsync(ns => ns.Id == request.Id);
                if(entity == null) 
                {
                    throw new NotFoundException(nameof(NodeSet), request.Id);
                }
                entity.Name.AddText(language, request.Name);
                entity.Description.AddText(language, request.Description);
                entity.VersionRationale.AddText(language, request.VersionRationale);
                entity.NodeSetType = request.IsSentinel ? NodeSetType.SENTINEL_CODE_LIST : NodeSetType.CODE_LIST;
                if(!String.IsNullOrWhiteSpace(request.Version)) 
                {
                    entity.Version = request.Version;
                }
                if(request.VersionDate.HasValue)
                {
                    entity.VersionDate = request.VersionDate.Value;
                }

                
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }

        }
    }
}