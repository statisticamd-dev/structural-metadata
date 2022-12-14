using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.Correspondences.Commands.UploadMappingCommand
{
    public class UploadMappingCommand : AbstractRequest, IRequest<long>
    {
        public long CorrespondenceId { get; set; }

        public List<MappingItemDto> MappingCsv { get; set; }

        public class Handler : IRequestHandler<UploadMappingCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(UploadMappingCommand request, CancellationToken cancellationToken)
            {
                var correspondence =  await _context.Correspondences.Where(c => c.Id == request.CorrespondenceId)
																				 
                                                        .Include(c => c.Mappings)
																					 
																					 
																				   
                                            .SingleOrDefaultAsync();
                if (correspondence == null)
                {
                    throw new NotFoundException(nameof(Correspondences), request.CorrespondenceId);
                }

																						 
                
                //on upload always delete previous mappings, if any
                if(correspondence.Mappings.Count() > 0) 
                {
                    correspondence.Mappings.Clear();
                    await _context.SaveChangesAsync(cancellationToken);
                }
                //_context.Correspondences.Update(correspondenceFound);

                List<Mapping> mappings = GetMappings(request.MappingCsv, correspondence);
                
                _context.Mappings.AddRange(mappings);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return correspondence.Id;
            }
		 

        private List<Mapping> GetMappings(List<MappingItemDto> mappingDtos, Correspondence correspondence)
        {
            List<Mapping> mappings = new();
            var sourceNodeSet = _context.NodeSets.Where(ns => ns.Id == correspondence.SourceId)
                                        .Include(ns => ns.Nodes)
                                        .FirstOrDefault();
            var targetNodeSet = _context.NodeSets.Where(ns => ns.Id == correspondence.TargetId)
                                        .Include(ns => ns.Nodes)
                                        .FirstOrDefault();
            foreach (var mapDto in mappingDtos)
            {
                var sourceNode = sourceNodeSet.Nodes.FirstOrDefault(n => n.Code == mapDto.SourceCode);
                
                if (sourceNode == null)
                {
                    throw new NotFoundException(nameof(Node), mapDto.SourceCode);
                }

                var targetNode = targetNodeSet.Nodes.FirstOrDefault((n) => n.Code == mapDto.TargetCode);
                
                if (targetNode == null)
                {
                    throw new NotFoundException(nameof(Node), mapDto.TargetCode);
                }

                var map = new Mapping
                {
                    Source = sourceNode,
                    Target = targetNode,
                    Correspondence = correspondence
                };
                correspondence.Mappings.Add(map);
                mappings.Add(map);

                //correspondenceFound.Mappings.Add(newMap);
            }

            return mappings;
        }
        }

       
    }
}
