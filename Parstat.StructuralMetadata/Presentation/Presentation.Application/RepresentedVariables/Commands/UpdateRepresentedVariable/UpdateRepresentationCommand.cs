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

namespace Presentation.Application.RepresentedVariables.Commands.UpdateRepresentedVariable
{
    public class UpdateRepresentationVariableCommand : AbstractRequest, IRequest<Unit>
    {    
        public long Id { get; set; }
        public long VariableId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? SentinelValueDomainId { get; set; }
        public long? SubstantiveValueDomainId { get; set; }

        public class Handler : IRequestHandler<UpdateRepresentationVariableCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateRepresentationVariableCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var representedVariable = await _context.RepresentedVariables
                    .FirstOrDefaultAsync(v => v.Id == request.Id);
              
                if(representedVariable == null)                 
                     throw new NotFoundException(nameof(RepresentedVariable), request.Id);
                
                if(request.SentinelValueDomainId.HasValue)                    
                   {
                       var sentinelValueDomainFound = await _context.ValueDomains.FirstOrDefaultAsync(v => v.Id == request.SentinelValueDomainId.Value);
                       if (sentinelValueDomainFound == null) throw new NotFoundException(nameof(ValueDomain), request.SentinelValueDomainId.Value); 

                       representedVariable.SentinelValueDomainId = request.SentinelValueDomainId.Value;
                   }
                     
                if(request.SubstantiveValueDomainId.HasValue)
                    { 
                       var substantiveValueDomainFound = await _context.ValueDomains.FirstOrDefaultAsync(v => v.Id == request.SubstantiveValueDomainId.Value);                
                       if (substantiveValueDomainFound == null) throw new NotFoundException(nameof(ValueDomain), request.SubstantiveValueDomainId.Value); 

                       representedVariable.SubstantiveValueDomainId = request.SubstantiveValueDomainId.Value;
                    }
                                
                if(!string.IsNullOrWhiteSpace(request.Name))
                    representedVariable.Name.AddText(language, request.Name);

                if(!string.IsNullOrWhiteSpace(request.Description))
                        representedVariable.Description.AddText(language, request.Description);                

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}