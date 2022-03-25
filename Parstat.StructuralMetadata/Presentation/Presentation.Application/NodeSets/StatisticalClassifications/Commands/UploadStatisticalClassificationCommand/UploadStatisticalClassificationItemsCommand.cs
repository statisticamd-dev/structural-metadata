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
using CsvHelper;
using System.Globalization;
using System.IO;
using Presentation.Domain.StructuralMetadata.Entities.Utilities;
using System.Collections.Generic;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadStatisticalClassificationCommand
{
    public class UploadStatisticalClassificationItemsCommand : AbstractRequest, IRequest<Unit>
    {
        public long StatisticalClassificationId  { get; set; }
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
                var statisticalClassification = _context.NodeSets.Where((x) => x.Id == request.StatisticalClassificationId).FirstOrDefault();
                if(statisticalClassification == null) throw new NotFoundException(nameof(NodeSet), request.StatisticalClassificationId);

                //deserialise and validate data
                List<StatisticalClassificationItems> scItems = null;
                using(TextReader reader = new StringReader(request.CsvItems))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    scItems = csv.GetRecords<StatisticalClassificationItems>().ToList();
                    if (scItems == null) throw new Exception("No statistical classification items were found!");
                }

                // get the maximum number of levels
                int maxLevel = scItems.Max((x) => x.LevelNumber);

                //loop through all levels, starting from root. Considering that LevelNumber starts from 1 and not 0
                for(int currentLevel = 1; currentLevel <= maxLevel; currentLevel++)
                {
                    //retrieve only current level items
                    var currentLevelItems = scItems.Where((x) => x.LevelNumber == currentLevel).ToList();
                    foreach(var singleItem in currentLevelItems)
                    {
                        Node parent = null;
                        if (!string.IsNullOrWhiteSpace(singleItem.ParentCode)) //get parent node if parentCode provided
                         parent = _context.Nodes.Where((x) => x.Code == singleItem.ParentCode).FirstOrDefault();

                        //get level from level number
                        var level = _context.Levels.Where((x) => x.LevelNumber == singleItem.LevelNumber).FirstOrDefault();
                        if (level == null) throw new NotFoundException(nameof(Level), singleItem.LevelNumber);
                        
                        var labelValues = new MultilanguageString  { En = singleItem.Label_En, Ro = singleItem.Label_Ro,  Ru = singleItem.Label_Ru };
                        var label = _context.Labels.Where((x) => x.Value == labelValues).FirstOrDefault();// get label if exists for the provided strings

                        //if label does not exists, create it
                        if(label == null)
                        {                            
                            var newLabel = new Label { Value = labelValues };

                            _context.Labels.Add(newLabel);
                            label = newLabel;
                        }

                        //finally, create the node and add it
                        var newNode = new Node {
                            Code = singleItem.Code,
                            Parent = parent,
                            ParentId = parent.Id,
                            NodeSet = statisticalClassification,
                            Level = level,
                            Label = label
                        };

                        _context.Nodes.Add(newNode);

                        //save changes, this node can be parent for the incoming ones
                        await _context.SaveChangesAsync(cancellationToken);                        
                    }
                }

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}