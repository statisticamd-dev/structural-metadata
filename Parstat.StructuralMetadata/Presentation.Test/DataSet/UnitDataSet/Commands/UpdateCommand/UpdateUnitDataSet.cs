using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand;
using Presentation.Application.DataSets.UnitDataSet.Commands.UpdateCommand;
using Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Threading.Tasks;

namespace Presentation.Test.DataSet.UnitDataSet.Commands.UpdateCommand
{
    using static Testing;
    public class UpdateUnitDataSet
    {
        [Test]
        public async Task UpdateUnitDataSetCommand_Should_Update_UnitDataSet()
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

            var updateUnitDataSetCommand = new UpdateUnitDataSetCommand
            {
                Id = dataSetId,
                Name = "Unit DataSet name updated",
                Description = "Unit data set description updated",
                Version = "1.1",
                VersionDate = DateTime.Now,
                ExchangeChannel = ExchangeChannel.QUESTIONNAIRE,
                ExchangeDirection = ExchangeDirection.COLLECT,
                StructureId = dataStructureResponse.Id,
                StatisticalProgramId = 1
            };

            // Act
             await SendAsync(updateUnitDataSetCommand);
            var dimensionalDataSetQuery = new GetUnitDataSetDetailsQuery
            {
                Id = dataSetId
            };

            var result = await SendAsync(dimensionalDataSetQuery);
            // Assert
            result.UnitDataSet.Name.Should().Be(updateUnitDataSetCommand.Name);
            result.UnitDataSet.Description.Should().Be(updateUnitDataSetCommand.Description);
            result.UnitDataSet.Version.Should().Be(updateUnitDataSetCommand.Version);
        }
    }
}
