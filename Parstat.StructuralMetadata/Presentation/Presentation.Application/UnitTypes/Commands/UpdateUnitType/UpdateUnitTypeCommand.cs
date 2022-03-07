using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.UnitTypes.Commands.UpdateUnitType
{
    public class UpdateUnitTypeCommand : AbstractRequest, IRequest<long>
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
         public string Version { get; set; }
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; }
        public string Definition { get; set; }

        public class Handler : IRequestHandler<UpdateUnitTypeCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(UpdateUnitTypeCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                
                var entity = await _context.UnitTypes.SingleOrDefaultAsync(ut => ut.Id == request.Id);

                if(entity == null) 
                {
                    throw new NotFoundException(nameof(UnitType), request.Id);
                }

                entity.Name.AddText(language, request.Name);
                entity.Description.AddText(language, request.Description);
                entity.Definition.AddText(language, request.Definition);
                entity.VersionRationale.AddText(language, request.VersionRationale);
                if(!String.IsNullOrEmpty(request.Version)) {
                    entity.Version = request.Version;
                }
                
                if(request.VersionDate != null) {
                    entity.VersionDate = request.VersionDate;
                }
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return entity.Id;
            }
        }
    }
}
