using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.AddComponent;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using Presentation.Test.DataStructures.Helper.DataStructures.UnitComponent;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Commands.AddComponent
{
    using static Testing;
    public class AddUnitComponent
    {
        [Test]
        public async Task AddUnitComponent_Should_Add_Component()
        {
            // Arrange
            var (dataStructureResponseId, representedVariableResponseId, logicalRecordResponseId) = await UnitComponent.InitializeReferences();           


            // Act
            var addRecordCommand = new AddUnitComponentCommand
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = "Logical record name",
                Description = "Logical record description",
                DataStructureId = dataStructureResponseId,
                Version = "1.0",
                RepresentedVariableId = representedVariableResponseId,
                Records = new List<long> { logicalRecordResponseId }
            };

            long result = await SendAsync(addRecordCommand);

            // Assert
            result.Should().BeGreaterThan(0);
        }
    }
}
