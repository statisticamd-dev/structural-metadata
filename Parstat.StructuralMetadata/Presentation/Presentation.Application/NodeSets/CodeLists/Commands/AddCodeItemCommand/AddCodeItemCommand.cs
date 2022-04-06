using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Models.StructuralMetadata;
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
        public MultilanguageStringDto Value{ get; set; }
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
                var codeItem = codeList.Nodes.FirstOrDefault(n => n.Code == request.Code);

                //codelist already containing the code
                if( codeItem != null)
                {
                    return codeList.Id;
                }

                var label = await getOrCreateLabelAsync(request.Value, language, cancellationToken);

                codeItem = new Node
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
                var codeList = await _context.NodeSets.Where(ns => ns.Id == codeListId)
                                                        .Include(ns => ns.Nodes)
                                                        .SingleOrDefaultAsync();
                if(codeList == null)
                {
                    throw new NotFoundException(nameof(NodeSet), codeListId);
                }
                return codeList;
            }

            private async Task<Label> getOrCreateLabelAsync(MultilanguageStringDto value, Language language, CancellationToken cancellationToken)
            {
                Label label = await GetLabelAsync(value, language);

                if(label == null)
                {
                    label = new Label() 
                    {
                        Value = value.asMUltilanguageString()
                    };

                    _context.Labels.Add(label);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                return label;
            }

            private async Task<Label> GetLabelAsync(MultilanguageStringDto value, Language language)
            {
                switch (language)
                {
                    case Presentation.Common.Domain.StructuralMetadata.Enums.Language.RO:
                        return  await _context.Labels.FirstOrDefaultAsync(l => l.Value.Ro == value.Ro);
                    case Presentation.Common.Domain.StructuralMetadata.Enums.Language.RU:
                        return await _context.Labels.FirstOrDefaultAsync(l => l.Value.Ru == value.Ru);
                    default:
                        return await _context.Labels.FirstOrDefaultAsync(l => l.Value.En == value.En);
                }
            }

        }
    }
}