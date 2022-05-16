using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.AddComponent;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateComponent;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using Presentation.Test.DataStructures.Helper.DataStructures.UnitComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Commands.UpdateComponent
{
    using static Testing;
    public class UpdateUnitComponent
    {
        [Test]
        public async Task UpdateUnitComponent_Should_Update_Component()
        {
            // Arrange
            var (dataStructureResponseId, representedVariableResponseId, logicalRecordResponseId) = await UnitComponent.InitializeReferences();

            var addUnitComponentCommand = new AddUnitComponentCommand
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = "Component name",
                Description = "Component description",
                DataStructureId = dataStructureResponseId,
                Version = "1.0",
                RepresentedVariableId = representedVariableResponseId,
                Type = ComponentType.MEASURE,
                Records = new List<long> { logicalRecordResponseId }
            };

            long componentId = await SendAsync(addUnitComponentCommand);

            var unitType = new UnitType
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Unit Type name new"),
                Description = MultilanguageString.Init(Language.EN, "Unit Type new description"),
                Version = "1.0",
                VersionDate = DateTime.Now
            };

            UnitType unitTypeResponse = await AddAsync(unitType);

            var logicalRecord = new LogicalRecord
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Logical record new name"),
                Description = MultilanguageString.Init(Language.EN, "Logical record new description"),
                Version = "1.0",
                DataStructureId = dataStructureResponseId,
                UnitTypeId = unitTypeResponse.Id
            };

            // Act
            var updateComponent = new UpdateUnitComponentCommand
            {                
                ComponentId = componentId,
                Name = "Component name updated",
                Description = "Component description updated",
                DataStructureId = dataStructureResponseId,
                Type = ComponentType.MEASURE,
                Records = new List<long> { logicalRecord.Id }
            };

            await SendAsync(updateComponent);

            var query = new GetUnitDataStructureQuery
            {
                Id = dataStructureResponseId
            };

            UnitDataStructureVm result = await SendAsync(query);
            var component = result.UnitDataStructure.Components.Where((c) => c.Id == componentId);

            // Assert            
            component.Count().Should().BeGreaterThan(0);
            component.FirstOrDefault().Id.Should().Be(componentId);
            component.FirstOrDefault().Name.Should().Be(updateComponent.Name);
            component.FirstOrDefault().Description.Should().Be(updateComponent.Description);
        }
    }
}
