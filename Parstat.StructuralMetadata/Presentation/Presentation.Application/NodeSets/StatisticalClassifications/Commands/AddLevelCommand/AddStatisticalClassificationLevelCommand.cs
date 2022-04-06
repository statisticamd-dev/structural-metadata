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
using Microsoft.EntityFrameworkCore;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.AddLevelCommand
{
    public class AddStatisticalClassificationLevelCommand : AbstractRequest, IRequest<long>
    {
        public long StatisticalClassificationId  { get; set; }
        public string LocalId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelNumber { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";

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

                var statisticalClassification = await _context.NodeSets.Where(ns => ns.Id == request.StatisticalClassificationId)
                                                                 .Include(ns => ns.Levels)
                                                                 .SingleOrDefaultAsync();
               
                if(statisticalClassification == null) 
                {
                    throw new NotFoundException(nameof(NodeSet), request.StatisticalClassificationId);
                }

                var level =  statisticalClassification.Levels.Where(l => l.LevelNumber == request.LevelNumber).FirstOrDefault();

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
                    Version = request.Version,
                    VersionDate = request.VersionDate,
                    VersionRationale = MultilanguageString.Init(language, request.VersionRationale),
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