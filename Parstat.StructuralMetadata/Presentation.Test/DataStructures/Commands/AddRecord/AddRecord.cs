using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.AddRecord;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Commands.AddRecord
{
    using static Testing;
    public class AddRecord
    {
        [Test]
        public async Task GetDataStructuresQuery_ShouldReturnDataStructure()
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
            Debug.WriteLine($"Data structure id {dataStructureResponse.Id}");

            // Act
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

            long result = await SendAsync(addRecordCommand);

            // Assert
            result.Should().BeGreaterThan(0);
        }
    }
}
