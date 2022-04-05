using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.RemoveLevelCommand
{
    public class RemoveStatisticalClassificationLevelCommand : AbstractRequest, IRequest
    {
        public long StatisticalClassificationId { get; set; }
        public long LevelId { get; set; }

        public class Handler : IRequestHandler<RemoveStatisticalClassificationLevelCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(RemoveStatisticalClassificationLevelCommand request, CancellationToken cancellationToken)
            {               
                var level = await _context.Levels.FirstOrDefaultAsync(l => l.NodeSetId == request.StatisticalClassificationId
                                                                    && l.Id == request.LevelId);
                _context.Levels.Remove(level);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
