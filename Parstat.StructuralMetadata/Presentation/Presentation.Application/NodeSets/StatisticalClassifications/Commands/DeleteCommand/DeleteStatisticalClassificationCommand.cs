using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.DeleteCommand
{
    public class DeleteStatisticalClassificationCommand : AbstractRequest, IRequest
    {
        public long Id { get; set; }

        public class Handler : IRequestHandler<DeleteStatisticalClassificationCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteStatisticalClassificationCommand request, CancellationToken cancellationToken)
            {               
                var entity = await _context.NodeSets
                    .FirstOrDefaultAsync(ns => ns.Id == request.Id);
               
               if(entity != null)
                {
                    _context.NodeSets.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);                
                }
 
                return Unit.Value;
            }
        }
    }
}
