using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.CreateCommand;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Commands.CreateCommand
{
    using static Testing;
    public class AddDataStructure
    {
        [Test]
        public async Task CreateUnitDataStructureCommand_Should_Add_DataStructure()
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

            // Act
            long result = await SendAsync(unitDataStructure);

            // Assert
            result.Should().BeGreaterThan(0);
        }
    }
}
