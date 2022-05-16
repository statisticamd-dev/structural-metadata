using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.AddComponent;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.RemoveComponent;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails;
using Presentation.Test.DataStructures.Helper.DataStructures.UnitComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Commands.RemoveComponent
{
    using static Testing;
    public class RemoveUnitComponent
    {
        [Test]
        public async Task RemoveComponentCommand()
        {
            // Arrange
            var (dataStructureResponseId, representedVariableResponseId, logicalRecordResponseId) = await UnitComponent.InitializeReferences();

            var addComponentCommand = new AddUnitComponentCommand
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = "Component name",
                Description = "Component description",
                DataStructureId = dataStructureResponseId,
                Version = "1.0",
                RepresentedVariableId = representedVariableResponseId,
                Records = new List<long> { logicalRecordResponseId }
            };

            long componentId = await SendAsync(addComponentCommand);

            // Act
            var removeComponentCommand = new RemoveUnitComponentCommand
            {
                UnitComponentId = componentId,
                UnitDataStructureId = dataStructureResponseId
            };

            await SendAsync(removeComponentCommand);

            var query = new GetUnitDataStructureQuery
            {
                Id = dataStructureResponseId
            };

            UnitDataStructureVm result = await SendAsync(query);
            var component = result.UnitDataStructure.Components.Where((c) => c.Id == componentId);

            // Assert
            component.Should().BeEmpty();
        }
    }
}
