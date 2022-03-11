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

namespace Presentation.Application.RepresentedVariables.Commands.CreateRepresentedVariable
{
    public class CreateRepresentationVariableCommand : AbstractRequest, IRequest<long>
    {
        public long VariableId { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? SentinelValueDomainId { get; set; }
        public long SubstantiveValueDomainId { get; set; }

        public class Handler : IRequestHandler<CreateRepresentationVariableCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(CreateRepresentationVariableCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var variable = await _context.Variables
                    .FirstOrDefaultAsync(v => v.Id == request.VariableId);

                if(variable == null)                 
                     throw new NotFoundException(nameof(Variable), request.VariableId);

                //In case SentinelValueDomainId is provided, check if this id corresponds to a valid ValueDomain
                if(request.SentinelValueDomainId != null)
                    {
                        var sentinelValueDomainFound = await _context.ValueDomains.FirstOrDefaultAsync(v => v.Id == request.SentinelValueDomainId);
                        if (sentinelValueDomainFound == null)  throw new NotFoundException(nameof(ValueDomain), request.SentinelValueDomainId); 
                    }

                var substantiveValueDomainFound = await _context.ValueDomains.FirstOrDefaultAsync(v => v.Id == request.SubstantiveValueDomainId);
                if (substantiveValueDomainFound == null)  throw new NotFoundException(nameof(ValueDomain), request.SubstantiveValueDomainId); 

                var newRepresentedVariableData = new RepresentedVariable 
                {
                    VariableId = request.VariableId,
                    LocalId = request.LocalId,
                    Name =  MultilanguageString.Init(language, request.Name),
                    SubstantiveValueDomainId = request.SubstantiveValueDomainId,
                    SentinelValueDomainId = request.SentinelValueDomainId,
                    Description = MultilanguageString.Init(language, request.Description)
                };
                
                _context.RepresentedVariables.Add(newRepresentedVariableData);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return newRepresentedVariableData.Id;
            }
        }
    }
}