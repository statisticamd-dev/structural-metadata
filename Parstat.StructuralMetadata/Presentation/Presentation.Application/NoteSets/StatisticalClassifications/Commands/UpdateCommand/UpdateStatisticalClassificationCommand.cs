﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Commands.UpdateCommand
{
    public class UpdateStatisticalClassificationCommand : AbstractRequest, IRequest<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Definition { get; set; }
        public string Link { get; set; }
        public string Version { get; set; }
        public DateTime? VersionDate { get; set; }
        public string VersionRationale { get; set; }

        public class Handler : IRequestHandler<UpdateStatisticalClassificationCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(UpdateStatisticalClassificationCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);

                var statisticalClassifications = await _context.NodeSets.FirstOrDefaultAsync(ns => ns.Id == request.Id);

                if (statisticalClassifications != null)
                    throw new NotFoundException(nameof(NodeSet), request.Id);

                if (!string.IsNullOrWhiteSpace(request.Name))
                    statisticalClassifications.Name = MultilanguageString.Init(language, request.Name);

                if (!string.IsNullOrWhiteSpace(request.Description))
                    statisticalClassifications.Description = MultilanguageString.Init(language, request.Description);

                if (!string.IsNullOrWhiteSpace(request.Definition))
                    statisticalClassifications.Definition = MultilanguageString.Init(language, request.Definition);

                if (!string.IsNullOrWhiteSpace(request.Link))
                    statisticalClassifications.Link = MultilanguageString.Init(language, request.Link);

                if (!string.IsNullOrWhiteSpace(request.Version))
                    statisticalClassifications.Version = request.Version;

                if (request.VersionDate.HasValue)
                    statisticalClassifications.VersionDate = request.VersionDate.Value;

                if (!string.IsNullOrWhiteSpace(request.VersionRationale))
                    statisticalClassifications.VersionRationale = MultilanguageString.Init(language, request.VersionRationale);

                var updatedStatisticalClasification = _context.NodeSets.Update(statisticalClassifications);
                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return updatedStatisticalClasification.Entity.Id;
            }
        }
    }
}