using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Utils;
using Microsoft.EntityFrameworkCore;
using Presentation.Common.Domain.StructuralMetadata.Enums;

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
                if(statisticalClassification.Levels.Count() > 0) {
                    return await createLevelNodes(statisticalClassification, request, cancellationToken);
                }
                else
                {
                    return await createNodes(statisticalClassification, request, cancellationToken);
                }
            }

            private async Task<Unit> createNodes(NodeSet statisticalClassification, UploadStatisticalClassificationItemsCommand request, CancellationToken cancellationToken) 
            {
                Node[] nodes = new Node[] {};
                foreach(StatisticalClassificationItemCsv itemCsv in
                            CSVRecordReader<StatisticalClassificationItemCsv>.Read(request.CsvItems))
                {
                    var labelValues = new MultilanguageString  { En = itemCsv.Label_En, 
                                                                 Ro = itemCsv.Label_Ro,  
                                                                 Ru = itemCsv.Label_Ru };
                    Label label = await getOrCreateLabel(labelValues, cancellationToken);

                    nodes.Append(createNode(statisticalClassification, itemCsv.Code, label));
                }
                _context.Nodes.AddRange(nodes);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }

            private async Task<Unit> createLevelNodes(NodeSet statisticalClassification, UploadStatisticalClassificationItemsCommand request, CancellationToken cancellationToken)
            {
                foreach(Level level in statisticalClassification.Levels.OrderBy(l => l.LevelNumber))
                {
                    Node[] nodes = new Node[] {};
                    foreach(StatisticalClassificationItemCsv itemCsv in
                            CSVRecordReader<StatisticalClassificationItemCsv>.ReadLevel(request.CsvItems, level.LevelNumber))
                    {
                        Node parent = await getParent(itemCsv.ParentCode, statisticalClassification);
                               
                        var labelValues = new MultilanguageString  { En = itemCsv.Label_En, 
                                                                     Ro = itemCsv.Label_Ro,  
                                                                     Ru = itemCsv.Label_Ru };
                        Label label = await getOrCreateLabel(labelValues, cancellationToken);

                        nodes.Append(createLevelNode(parent, level, statisticalClassification, itemCsv.Code, label, request.AggregationType));
                    }
                    _context.Nodes.AddRange(nodes);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                return Unit.Value;
            }

            private async Task<Node> getParent(string parentCode, NodeSet statisticalClassification)
            {
                if(String.IsNullOrWhiteSpace(parentCode))
                {
                    return null;
                }
                return await _context.Nodes.Where(n => n.Code == parentCode 
                                                && n.NodeSet == statisticalClassification)
                                                .FirstOrDefaultAsync();
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

            private Node createLevelNode(Node parent, Level level, NodeSet statisticalClassification, string code, Label label, AggregationType aggregationType)
            {
                Node node = new Node() 
                {
                    Parent = parent,
                    Level = level,
                    NodeSet = statisticalClassification,
                    Code = code,
                    AggregationType = aggregationType,
                    Label = label
                };

                return node;
            }

             private Node createNode(NodeSet statisticalClassification, string code, Label label)
            {
                Node node = new Node() 
                {
                    NodeSet = statisticalClassification,
                    Code = code,
                    AggregationType = AggregationType.NONE,
                    Label = label
                };
                return node;
            }
        }
    }
}