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

                var newRepresentedVariableData = new RepresentedVariable {

                        VariableId = request.VariableId,
                        LocalId = request.LocalId,
                        Name =  MultilanguageString.Init(language, request.Name),
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