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

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UpdateLevelCommand
{
    public class UpdateStatisticalClassificationLevelCommand : AbstractRequest, IRequest<long>
    {
        public long StatisticalClassificationId { get; set; }
        public long LevelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<UpdateStatisticalClassificationLevelCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(UpdateStatisticalClassificationLevelCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);

                var statisticalClassification = await _context.NodeSets.Where((x) => x.Id == request.StatisticalClassificationId)
                                                    .Include(ns => ns.Levels)
                                                    .SingleOrDefaultAsync();
               
                if(statisticalClassification == null) 
                {
                    throw new NotFoundException(nameof(NodeSet), request.StatisticalClassificationId);
                }

                var level =  statisticalClassification.Levels.Where(l => l.Id == request.LevelId).FirstOrDefault();

                if(level != null)
                {
                    throw new NotFoundException(nameof(Level), request.LevelId);
                }

                level.Name.AddText(language, request.Name);
                level.Description.AddText(language, request.Description);
                _context.Levels.Update(level);
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return statisticalClassification.Id;
            }
        }
    }
}
