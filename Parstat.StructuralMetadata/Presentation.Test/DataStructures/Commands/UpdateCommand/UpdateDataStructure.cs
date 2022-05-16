using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.CreateCommand;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateCommand;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Commands.UpdateCommand
{
    using static Testing;
    public class UpdateDataStructure
    {
        [Test]
        public async Task UpdateUnitDataStructureCommand_Should_Update_DataStructure()
        {
            // Arrange
            var unitDataStructure = new CreateUnitDataStructureCommand
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = "Logical record name",
                Description = "Logical record description",
                Version = "1.0",
                VersionDate = DateTime.Now,
                Type = DataSetType.UNIT
            };

            long unitDataStructureResult = await SendAsync(unitDataStructure);

            // Act
            var unitDataStructureUpdate = new UpdateUnitDataStructureCommand
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = "Logical record name v1.1",
                Description = "Logical record description v1.1",
                Version = "1.1",
                VersionDate = DateTime.Now,
                Id = unitDataStructureResult
            };

            await SendAsync(unitDataStructureUpdate);

            var query = new GetUnitDataStructureQuery
            {
                Id = unitDataStructureResult
            };

            UnitDataStructureVm result = await SendAsync(query);

            // Assert            
            result.UnitDataStructure.Id.Should().Be(unitDataStructureResult);
            result.UnitDataStructure.Name.Should().Be(unitDataStructureUpdate.Name);
            result.UnitDataStructure.Description.Should().Be(unitDataStructureUpdate.Description);
            result.UnitDataStructure.Version.Should().Be(unitDataStructureUpdate.Version);
        }
    }
}
