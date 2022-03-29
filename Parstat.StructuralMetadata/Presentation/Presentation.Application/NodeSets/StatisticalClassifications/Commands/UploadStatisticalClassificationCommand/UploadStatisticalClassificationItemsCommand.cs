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

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadStatisticalClassificationCommand
{
    public class UploadStatisticalClassificationItemsCommand : AbstractRequest, IRequest<Unit>
    {
        public long StatisticalClassificationId  { get; set; }
        public AggregationType AggregationType { get; set; }
        public List<StatisticalClassificationItemCsvDto> RootItems { get; set; }        

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

                await addLabelsToCSV(request.RootItems, cancellationToken);

                createNodeRecursivly(statisticalClassification, request.RootItems, request.AggregationType);

                _context.NodeSets.Update(statisticalClassification);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            private async Task<Unit> addLabelsToCSV(List<StatisticalClassificationItemCsvDto> rootItems, CancellationToken cancellationToken)
            {
                if(rootItems == null || rootItems.Count == 0) 
                {
                    return Unit.Value;
                }
                foreach(StatisticalClassificationItemCsvDto item in rootItems)
                {
                    MultilanguageString multilanguageString = new MultilanguageString() {
                        En = item.ValueEn,
                        Ro = item.ValueRo,
                        Ru = item.ValueRu
                    };
                    Label label = await getOrCreateLabel(multilanguageString, cancellationToken);
                    item.LabelId = label.Id;
                    await addLabelsToCSV(item.Children, cancellationToken);
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

            private List<Node> createNodeRecursivly(NodeSet statisticalClassification, List<StatisticalClassificationItemCsvDto> rootNodes, AggregationType aggregationType)
            {
                if(rootNodes == null || rootNodes.Count == 0) {
                    return null;
                }

                List<Node> nodes = new List<Node>();

                foreach( StatisticalClassificationItemCsvDto item in rootNodes)
                {
                    Node node = new Node() 
                    {
                        Code = item.Code,
                        AggregationType = aggregationType,
                        Level = statisticalClassification.Levels.Where(l => l.LevelNumber == item.LevelNumber).FirstOrDefault(),
                        LabelId =  item.LabelId.Value,
                        NodeSet = statisticalClassification,
                        Children = createNodeRecursivly(statisticalClassification, item.Children, aggregationType)
                    };
                    nodes.Add(node);
                    statisticalClassification.Nodes.Add(node);
                }
                return nodes;
            }
        }
    }
}