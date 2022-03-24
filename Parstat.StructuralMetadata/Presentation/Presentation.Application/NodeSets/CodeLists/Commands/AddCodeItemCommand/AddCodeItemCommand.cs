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

namespace Presentation.Application.NodeSets.CodeLists.Commands.AddCodeItemCommand
{
    public class AddCodeItemCommand : AbstractRequest, IRequest<string>
    {
        public long NodeSetId { get; set; }
        public string Code { get; set; }
        public long LabelId { get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<AddCodeItemCommand, string>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<string> Handle(AddCodeItemCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var codeList = await getCodeListAsync(request.NodeSetId);
               
                //codelist already containing the code
                if(codeList.Nodes.FirstOrDefault(n => n.Code.Equals(request.Code)) != null)
                {
                    return request.Code;
                }
                
                var label = await getLabelAsync(request.LabelId);

                var codeItem = new Node
                {
                    Code = request.Code,
                    Label = label,
                    NodeSet = codeList,
                    AggregationType = AggregationType.NONE,
                    Description = MultilanguageString.Init(language, request.Description)
                };

                codeList.Nodes.Add(codeItem);
                await _context.SaveChangesAsync(cancellationToken);

                return request.Code;
            }

            private async Task<NodeSet> getCodeListAsync(long codeListId)
            {
                var codeList = await _context.NodeSets.FirstOrDefaultAsync(ns => ns.Id == codeListId);
                if(codeList == null)
                {
                    throw new NotFoundException(nameof(NodeSet), codeListId);
                }
                return codeList;
            }
            private async Task<Label> getLabelAsync(long labelId)
            {
                var label = await _context.Labels.FirstOrDefaultAsync(l => l.Id == labelId);
                if(label == null)
                {
                    throw new NotFoundException(nameof(Label), labelId);
                }
                return label;
            }

        }
    }
}