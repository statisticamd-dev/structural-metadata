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

namespace Presentation.Application.Labels.Commands.UpdateLabel
{
    public class UpdateLabelCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }
        public string Value { get; set; }

        public class Handler : IRequestHandler<UpdateLabelCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateLabelCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var label = await _context.Labels.FirstOrDefaultAsync(l => l.Id == request.Id);
                
                if(label == null)
                {
                    throw new NotFoundException(nameof(Label), request.Id);
                }
                label.Value.AddText(language, request.Value);
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }

        }
    }
}