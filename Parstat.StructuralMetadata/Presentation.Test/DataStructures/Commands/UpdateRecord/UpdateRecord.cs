using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.AddRecord;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateRecord;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace Presentation.Test.DataStructures.Commands.UpdateRecord
{
    using static Testing;
    public class UpdateRecord
    {
        [Test]
        public async Task UpdateRecordCommand_Should_Update_Record()
        {
            // Arrange
            var dataStructure = new DataStructure
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Data structure name"),
                Description = MultilanguageString.Init(Language.EN, "Description of data structure"),
                Version = "1.0",
                Group = "Data structure group",
                VersionDate = DateTime.Now
            };
            var unitType = new UnitType
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Person"),
                Description = MultilanguageString.Init(Language.EN, "Description of person"),
                Version = "1.0",
                VersionDate = DateTime.Now
            };
            DataStructure dataStructureResponse = await AddAsync(dataStructure);
            UnitType unitTypeResponse = await AddAsync(unitType);

            var addRecordCommand = new AddRecordCommand
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = "Logical record name",
                Description = "Logical record description",
                Version = "1.0",
                VersionDate = DateTime.Now,
                DataStructureId = dataStructureResponse.Id,
                UnitTypeId = unitTypeResponse.Id
            };

            long addRecordId = await SendAsync(addRecordCommand);

            // Act          
            var updateRecord = new UpdateRecordCommand
            {
                DataStructureId = dataStructureResponse.Id,
                Name = "Data structure name v1.1",
                Description = "Description of data structure v1.1",
                Version = "1.1",                
                RecordId = addRecordId
            };

            await SendAsync(updateRecord);

            var query = new GetUnitDataStructureQuery
            {
                Id = dataStructureResponse.Id
            };

            UnitDataStructureVm result = await SendAsync(query);

            // Assert
            result.UnitDataStructure.Records.Should().HaveCountGreaterThan(0);
            var logicalRecords = result.UnitDataStructure.Records.Where((r) => r.Id == addRecordId);

            logicalRecords.Should().HaveCount(1);
            logicalRecords.FirstOrDefault().Name.Should().Be(updateRecord.Name);
            logicalRecords.FirstOrDefault().Description.Should().Be(updateRecord.Description);
            logicalRecords.FirstOrDefault().Version.Should().Be(updateRecord.Version);

        }
    }
}
