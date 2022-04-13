using System;
using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Presentation.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System.Collections.Generic;
using Presentation.Application.Common.Models.StructuralMetadata;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadItemsCommand
{
    public class UploadStatisticalClassificationItemsCommand : AbstractRequest, IRequest<long>
    {
        public long StatisticalClassificationId  { get; set; }
        public AggregationType AggregationType { get; set; }
        public List<StatisticalClassificationItemCsvDto> RootItems { get; set; }        

        public class Handler : IRequestHandler<UploadStatisticalClassificationItemsCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(UploadStatisticalClassificationItemsCommand request, CancellationToken cancellationToken)
            {    
                          
                //Check if provided statistical classification id exists
                var statisticalClassification = await _context.NodeSets.Where((x) => x.Id == request.StatisticalClassificationId)
                                                                        .Include(ns => ns.Nodes)
                                                                        .Include(ns => ns.Levels)
                                                                        .SingleOrDefaultAsync();
                if(statisticalClassification == null) 
                {
                    throw new NotFoundException(nameof(NodeSet), request.StatisticalClassificationId);
                }

                //delete previous nodes
                if(statisticalClassification.Nodes.Count > 0) {
                    _context.Nodes.RemoveRange(statisticalClassification.Nodes);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                await addLabelsRecursivly(request.RootItems, cancellationToken);

                createNodeRecursivly(statisticalClassification, request.RootItems, request.AggregationType);

                _context.NodeSets.Update(statisticalClassification);

                await _context.SaveChangesAsync(cancellationToken);

                return statisticalClassification.Id;
            }

            private async Task<Unit> addLabelsRecursivly(List<StatisticalClassificationItemCsvDto> rootItems, CancellationToken cancellationToken)
            {
                if(rootItems == null || rootItems.Count == 0) 
                {
                    return Unit.Value;
                }
                foreach(StatisticalClassificationItemCsvDto item in rootItems)
                {
                    Label label = await getOrCreateLabel(item.label, cancellationToken);
                    item.LabelId = label.Id;
                    await addLabelsRecursivly(item.Children, cancellationToken);
                }
                return Unit.Value;
            }

            private async Task<Label> getOrCreateLabel(MultilanguageStringDto multilanguageStringDto, CancellationToken cancellationToken)
            {
                IQueryable<Label> query = queryLabels(multilanguageStringDto);
                if(query != null)
                {
                    Label label = await query.FirstOrDefaultAsync(cancellationToken);
                    if(label != null)
                    {
                        if(UpdateLabelLingauges(label, multilanguageStringDto)) 
                        {
                            _context.Labels.Update(label);
                            await _context.SaveChangesAsync(cancellationToken);
                        }
                        return label;
                    }

                    label = new Label()
                    {
                        Value = multilanguageStringDto.asMUltilanguageString()
                    };
                    _context.Labels.Add(label);
                    await _context.SaveChangesAsync(cancellationToken);

                    return label;
                }
                throw new Exception("CSV file content is not correct");
                
            }

            private IQueryable<Label> queryLabels(MultilanguageStringDto multilanguageStringDto)
            {
                if(!String.IsNullOrEmpty(multilanguageStringDto.En))
                {
                    return _context.Labels.Where(l => l.Value.En == multilanguageStringDto.En);
                }
                if(!String.IsNullOrEmpty(multilanguageStringDto.Ro))
                {
                    return _context.Labels.Where(l => l.Value.Ro == multilanguageStringDto.Ro);
                }
                if(!String.IsNullOrEmpty(multilanguageStringDto.Ru))
                {
                    return _context.Labels.Where(l => l.Value.Ru == multilanguageStringDto.Ru);
                }
                return null;
            }
            private bool UpdateLabelLingauges(Label label, MultilanguageStringDto multilanguageStringDto) 
            {
                if(!String.IsNullOrEmpty(multilanguageStringDto.En)
                        && String.IsNullOrEmpty(label.Value.En) 
                        && label.Value.En != multilanguageStringDto.En) 
                {
                   label.Value.En = multilanguageStringDto.En;
                   return true;
                }

                if(!String.IsNullOrEmpty(multilanguageStringDto.Ro) 
                       && String.IsNullOrEmpty(label.Value.En)
                       &&label.Value.Ro != multilanguageStringDto.Ro) 
                {
                   label.Value.Ro = multilanguageStringDto.Ro;
                   return true;
                }

                if(!String.IsNullOrEmpty(multilanguageStringDto.Ru)
                       && String.IsNullOrEmpty(label.Value.En) 
                       && label.Value.Ru != multilanguageStringDto.Ru) 
                {
                   label.Value.Ru = multilanguageStringDto.Ru;
                   return true;
                }

                return false;
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