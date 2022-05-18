using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand;
using Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Presentation.Test.DataSet.DimansionalDataSet.Queries.GetDimensionalDataSet
{
    using static Testing;
    public class UnitDataSetDetailsQuery
    {
        [Test]
        public async Task GetUnitDataSetDetailsQuery_Should_Retrieve_Unit_DataSet_Details()
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

            var unitDataSetId = await SendAsync(createUnitDataSetCommand);
            Debug.WriteLine($"Unit data set id is {unitDataSetId}");

            // Act
            var dimensionalDataSetQuery = new GetUnitDataSetDetailsQuery
            {
                Id = unitDataSetId
            };

            var result = await SendAsync(dimensionalDataSetQuery);

            // Assert
            result.UnitDataSet.Id.Should().Be(unitDataSetId);
            result.UnitDataSet.Name.Should().Be(createUnitDataSetCommand.Name);
            result.UnitDataSet.Description.Should().Be(createUnitDataSetCommand.Description);
            result.UnitDataSet.Version.Should().Be(createUnitDataSetCommand.Version);
        }
    }
}
