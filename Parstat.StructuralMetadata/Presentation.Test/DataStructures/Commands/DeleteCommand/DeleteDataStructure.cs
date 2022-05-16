using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.CreateCommand;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.DeleteCommand;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Commands.DeleteCommand
{
    using static Testing;
    public class DeleteDataStructure
    {
        [Test]
        public async Task DeleteUnitDataStructureCommand_Should_Delete_DataStructure()
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
            var unitDataStructureUpdate = new DeleteUnitDataStructureCommand
            {               
                Id = unitDataStructureResult
            };

            await SendAsync(unitDataStructureUpdate);

            var query = new GetUnitDataStructureQuery
            {
                Id = unitDataStructureResult
            };

            UnitDataStructureVm result = await SendAsync(query);

            // Assert            
            result.UnitDataStructure.Should().BeNull();
        }
    }
}
