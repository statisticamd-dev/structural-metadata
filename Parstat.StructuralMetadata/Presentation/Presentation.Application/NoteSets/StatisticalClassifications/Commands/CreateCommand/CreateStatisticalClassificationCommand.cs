using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Commands.CreateCommand
{
    public class CreateStatisticalClassificationCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Definition { get; set; }
        public string Link { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";

        public class Handler : IRequestHandler<CreateStatisticalClassificationCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(CreateStatisticalClassificationCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);

                 var newNodeSet = new NodeSet() {
                        Name = MultilanguageString.Init(language, request.Name),
                        Description = MultilanguageString.Init(language, request.Description),
                        Definition = MultilanguageString.Init(language, request.Definition),
                        Link = MultilanguageString.Init(language, request.Link),
                        Version = request.Version,
                        VersionDate = request.VersionDate,
                        VersionRationale =  MultilanguageString.Init(language, request.VersionRationale),
                        NodeSetType = NodeSetType.STATISTICAL_CLASSIFICATION,
                 };

                var insertedNodeSet = _context.NodeSets.Add(newNodeSet);
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return insertedNodeSet.Entity.Id;
            }
        }
    }
}