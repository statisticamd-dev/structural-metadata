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
    public class AddCodeItemCommand : AbstractRequest, IRequest<long>
    {
        public long NodeSetId { get; set; }
        public string Code { get; set; }
        public string Value{ get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<AddCodeItemCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(AddCodeItemCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var codeList = await getCodeListAsync(request.NodeSetId);
               
                //codelist already containing the code
                if(codeList.Nodes.FirstOrDefault(n => n.Code.Equals(request.Code)) != null)
                {
                    return codeList.Id;
                }
                
                var label = await getOrCreateLabelAsync(request.Value, language, cancellationToken);

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

                return codeList.Id;
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
            private async Task<Label> getOrCreateLabelAsync(string value, Language language, CancellationToken cancellationToken)
            {
                var label = await _context.Labels.FirstOrDefaultAsync(l => filterLabel(l, language, value));
                if(label == null)
                {
                    label = new Label() 
                    {
                        Value = MultilanguageString.Init(language, value)
                    };
                    _context.Labels.Add(label);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                return label;
            }

            Func<Label, Language, string, bool> filterLabel = (Label label, Language language, string value) =>
            {
                switch (language)
                {
                    case Presentation.Common.Domain.StructuralMetadata.Enums.Language.RU:
                        return label.Value.Ru == value;
                    case Presentation.Common.Domain.StructuralMetadata.Enums.Language.RO:
                        return label.Value.Ro == value;
                    default:
                        return label.Value.En == value;
                }

            };

        }
    }
}