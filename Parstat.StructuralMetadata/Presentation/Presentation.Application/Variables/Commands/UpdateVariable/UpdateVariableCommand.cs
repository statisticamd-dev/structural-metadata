using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.Variables.Commands.UpdateVariable
{
    public class UpdateVariableCommand : AbstractRequest, IRequest<Unit>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";
        public string Definition { get; set; }
        public long MeasuresId { get; set; }

        public class Handler : IRequestHandler<UpdateVariableCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateVariableCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
               
               var entity = await _context.Variables.SingleOrDefaultAsync(ns => ns.LocalId == request.LocalId);
               
               if(entity == null) throw new NotFoundException(nameof(Variables), request.LocalId);

                entity.Name.AddText(language, request.Name);
                entity.Description.AddText(language, request.Description);
                entity.Version = request.Version;
                entity.VersionDate = request.VersionDate;
                entity.VersionRationale.AddText(language, request.VersionRationale);
                entity.Definition.AddText(language, request.Definition);
                entity.MeasuresId = request.MeasuresId;                                  

                _context.Variables.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }

        }
    }
}