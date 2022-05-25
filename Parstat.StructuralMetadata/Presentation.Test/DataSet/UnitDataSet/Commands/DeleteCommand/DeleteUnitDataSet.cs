using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand;
using Presentation.Application.DataSets.UnitDataSet.Commands.DeleteCommand;
using Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Threading.Tasks;

namespace Presentation.Test.DataSet.UnitDataSet.Commands.DeleteCommand
{
    using static Testing;
    public class DeleteUnitDataSet
    {
        [Test]
        public async Task DeleteUnitDataSetCommand_Should_Delete_UnitDataSet()
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

            DataStructure dataStructureResponse = await AddAsync(dataStructure);

            var createUnitDataSetCommand = new CreateUnitDataSetCommand
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = "Unit DataSet name",
                Description = "Unit data set description",
                Version = "1.0",
                VersionDate = DateTime.Now,
                ExchangeChannel = ExchangeChannel.QUESTIONNAIRE,
                ExchangeDirection = ExchangeDirection.COLLECT,
                StructureId = dataStructureResponse.Id,
                StatisticalProgramId = 1
            };
            long dataSetId = await SendAsync(createUnitDataSetCommand);

            var deleteUnitDataSetCommand = new DeleteUnitDataSetCommand
            {
                 Id = dataSetId
            };

            // Act
            await SendAsync(deleteUnitDataSetCommand);

            var dimensionalDataSetQuery = new GetUnitDataSetDetailsQuery
            {
                Id = dataSetId
            };

            var result = await SendAsync(dimensionalDataSetQuery);

            // Assert
            result.UnitDataSet.Should().BeNull();
        }
    }
}
