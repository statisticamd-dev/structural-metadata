using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataSets.DimansionalDataSet.Commands.CreateCommand
{
    public class CreateDimensionalDataSetCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime? ReportingBegin { get; set; }
        public DateTime? ReportingEnd { get; set; }
        public long StructureId { get; set; }
        public long StatisticalProgramId { get; set; }
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";


        public class Handler : IRequestHandler<CreateDimensionalDataSetCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateDimensionalDataSetCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);

                var dataSet = new DataSet
                {
                    LocalId = request.LocalId,
                    StructureId = request.StructureId,
                    Name = MultilanguageString.Init(language, request.Name),
                    Description = MultilanguageString.Init(language, request.Description),
                    Version = request.Version,
                    VersionDate = request.VersionDate,
                    VersionRationale = MultilanguageString.Init(language, request.VersionRationale),
                    Type = DataSetType.DIMENSIONAL,
                    ReportingBegin = request.ReportingBegin,
                    ReportingEnd = request.ReportingEnd
                };

                _context.DataSets.Add(dataSet);

                await _context.SaveChangesAsync(cancellationToken);

                return dataSet.Id;
            }
        }
    }
}
