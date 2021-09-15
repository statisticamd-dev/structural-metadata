using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.CodeLists.Commands.AddCodeItemCommand
{
    public class AddCodeItemCommand : AbstractRequest, IRequest
    {
        public long NodeSetId { get; set; }
        public string Code { get; set; }
        public long LabelId { get; set; }

        public class Handler : IRequestHandler<AddCodeItemCommand>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(AddCodeItemCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var codeList = await _context.NodeSets.FirstOrDefaultAsync(ns => ns.Id == request.NodeSetId);
                var label = await _context.Labels.FirstOrDefaultAsync(l => l.Id == request.LabelId);
                if(codeList == null)
                {
                    throw new NotFoundException(nameof(NodeSet), request.NodeSetId);
                }
                if(label == null)
                {
                    throw new NotFoundException(nameof(Label), request.LabelId);
                }
                var codeItem = new Node
                {
                    Code = request.Code,
                    Label = label
                };

                codeList.Nodes.Append(codeItem);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }

        }
    }
}