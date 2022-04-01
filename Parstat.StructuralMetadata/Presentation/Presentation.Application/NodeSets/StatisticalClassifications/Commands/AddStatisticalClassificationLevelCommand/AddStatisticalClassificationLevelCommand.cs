using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Presentation.Application.Common.Exceptions;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.AddStatisticalClassificationLevelCommand
{
    public class AddStatisticalClassificationLevelCommand : AbstractRequest, IRequest<long>
    {
        public long StatisticalClassificationId  { get; set; }
        public string LocalId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelNumber { get; set; }

        public class Handler : IRequestHandler<AddStatisticalClassificationLevelCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(AddStatisticalClassificationLevelCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);

                var statisticalClassification = _context.NodeSets.Where((x) => x.Id == request.StatisticalClassificationId).FirstOrDefault();
               
                if(statisticalClassification == null) 
                {
                    throw new NotFoundException(nameof(NodeSet), request.StatisticalClassificationId);
                }

                var level =  statisticalClassification.Levels.Where((x) => x.LevelNumber == request.LevelNumber).FirstOrDefault();

                if(level != null)
                {
                    //Level already exists, return level Id and do nothing more
                    return statisticalClassification.Id;
                }

                var newLevel = new Level {
                    LocalId = request.LocalId,
                    LevelNumber = request.LevelNumber,
                    Name = MultilanguageString.Init(language, request.Name),
                    Description = MultilanguageString.Init(language, request.Description),
                    NodeSet = statisticalClassification
                };
                
                _context.Levels.Add(newLevel);               
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return statisticalClassification.Id;
            }
        }
    }
}