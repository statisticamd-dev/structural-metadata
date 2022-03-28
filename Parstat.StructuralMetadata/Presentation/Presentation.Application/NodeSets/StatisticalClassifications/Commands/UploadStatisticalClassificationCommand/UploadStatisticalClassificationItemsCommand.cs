using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Presentation.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System.Collections.Generic;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadStatisticalClassificationCommand.translator;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadStatisticalClassificationCommand
{
    public class UploadStatisticalClassificationItemsCommand : AbstractRequest, IRequest<Unit>
    {
        public long StatisticalClassificationId  { get; set; }
        public AggregationType AggregationType { get; set; }
        public string CsvItems { get; set; }        

        public class Handler : IRequestHandler<UploadStatisticalClassificationItemsCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(UploadStatisticalClassificationItemsCommand request, CancellationToken cancellationToken)
            {    
                          
                //Check if provided statistical classification id exists
                var statisticalClassification = await _context.NodeSets.Where((x) => x.Id == request.StatisticalClassificationId)
                                                                        .FirstOrDefaultAsync();
                if(statisticalClassification == null) 
                {
                    throw new NotFoundException(nameof(NodeSet), request.StatisticalClassificationId);
                }
                
                List<StatisticalClassificationItemCsv> csvItems = UploadCommandTranslator.ReadCSV(request.CsvItems);

                await createLabelDictionary(csvItems, request.Language, cancellationToken);

                UploadCommandTranslator.TranslateRecursivly(csvItems, statisticalClassification, request.AggregationType);

                _context.NodeSets.Update(statisticalClassification);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            private async Task<Unit> createLabelDictionary(IEnumerable<StatisticalClassificationItemCsv> items, string language, CancellationToken cancellationToken)
            {
                Dictionary<long, string> languageDictionary = new Dictionary<long, string>();
                foreach(StatisticalClassificationItemCsv item in items)
                {
                    MultilanguageString multilanguageString = new MultilanguageString() {
                        En = item.Label_En,
                        Ro = item.Label_Ro,
                        Ru = item.Label_Ru
                    };
                    Label label = await getOrCreateLabel(multilanguageString, cancellationToken);
                    item.LabelId = label.Id;
                }
                return Unit.Value;
            }

                        private async Task<Label> getOrCreateLabel(MultilanguageString multilanguageString, CancellationToken cancellationToken)
            {
                Label label = await _context.Labels.Where(l => l.Value == multilanguageString).FirstOrDefaultAsync();
                if(label == null) 
                {
                    label = new Label() {Value = multilanguageString};
                    _context.Labels.Add(label);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                return label;
            }
        }
    }
}