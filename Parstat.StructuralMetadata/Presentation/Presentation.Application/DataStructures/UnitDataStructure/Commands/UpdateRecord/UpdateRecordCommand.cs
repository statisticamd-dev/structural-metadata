using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateRecord
{
    public class UpdateRecordCommand : AbstractRequest, IRequest<Unit>
    {
        public int RecordId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime? VersionDate { get; set; }
        public string VersionRationale { get; set; }
        public long DataStructureId { get; set; }
        public long UnitTypeId { get; set; }
        public long? ParentId { get; set; }

        public class Handler : IRequestHandler<UpdateRecordCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);
                
                var dataStructure = await GetDataStructureAsync(request.DataStructureId);
                var unitType = await GetUnitTypeAsync(request.UnitTypeId);
                var record = dataStructure.LogicalRecords.Where(lr => lr.Id == request.RecordId).FirstOrDefault();
                if (record == null)
                {
                    throw new NotFoundException(nameof(LogicalRecord), request.RecordId );
                }
                var parentRecord = dataStructure.LogicalRecords.Where(lr => lr.Id == request.ParentId).FirstOrDefault();
                record.Name.AddText(language, request.Name);
                record.Description.AddText(language, request.Description);
                record.VersionRationale.AddText(language, request.VersionRationale);
                if (!string.IsNullOrWhiteSpace(request.Version))
                {
                    record.Version = request.Version;
                }
                if (request.VersionDate.HasValue)
                {
                    record.VersionDate = request.VersionDate.Value;
                }
                record.Parent = parentRecord;    
                record.UnitType = unitType;            

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }

            private async Task<DataStructure> GetDataStructureAsync(long dataStructureId) 
            {
                var dataStructure = await _context.DataStructures
                                                        .Where(ds => ds.Id == dataStructureId)
                                                        .Include(ds => ds.LogicalRecords)
                                                        .SingleOrDefaultAsync();

                if(dataStructure == null) 
                {
                    throw new NotFoundException(nameof(DataStructure), dataStructureId );
                }   
                return dataStructure;

            }

            private async Task<UnitType> GetUnitTypeAsync(long untiTypeId) 
            {
                var unitType = await _context.UnitTypes
                                                        .Where(ut => ut.Id == untiTypeId)
                                                        .SingleOrDefaultAsync();

                if(unitType == null) 
                {
                    throw new NotFoundException(nameof(UnitType), untiTypeId );
                }   
                return unitType;

            }
        }        
    }
}