using MediatR;
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
                var correspondence = _context.Correspondences.FirstOrDefault((x) => x.Id == request.CorrespondenceId);
                if (correspondence != null)
                {
                    throw new NotFoundException(nameof(Correspondences), request.CorrespondenceId);
                }

                List<Mapping> newMaps = GetMappings(request.MappingCsv, correspondence);

                var mappings = correspondence.Mappings;
                if (mappings != null)
                {
                    _context.Mappings.RemoveRange(mappings);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                //_context.Correspondences.Update(correspondenceFound);

                _context.Mappings.AddRange(newMaps);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return correspondence.Id;
            }
        }

        private static List<Mapping> GetMappings(List<MappingItemDto> mappingsData, Correspondence correspondence)
        {
            List<Mapping> mappings = new();
            foreach (var singleMapp in mappingsData)
            {
                var sourceNode = correspondence.Source.Nodes.FirstOrDefault((n) => n.Code == singleMapp.SourceCode);
                if (sourceNode == null)
                {
                    throw new NotFoundException(nameof(Node), singleMapp.SourceCode);
                }

                var targetNode = correspondence.Target.Nodes.FirstOrDefault((n) => n.Code == singleMapp.TargetSource);
                if (targetNode == null)
                {
                    throw new NotFoundException(nameof(Node), singleMapp.TargetSource);
                }

                var newMap = new Mapping
                {
                    Source = sourceNode,
                    Target = targetNode,
                    Correspondence = correspondence
                };

                mappings.Add(newMap);

                //correspondenceFound.Mappings.Add(newMap);
            }

            return mappings;
        }
    }
}
