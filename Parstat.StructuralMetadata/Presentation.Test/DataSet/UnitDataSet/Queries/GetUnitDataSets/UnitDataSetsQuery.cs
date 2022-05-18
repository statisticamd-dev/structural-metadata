using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand;
using Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSets;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Test.DataSet.UnitDataSet.Queries.GetUnitDataSets
{
    using static Testing;
    public class UnitDataSetsQuery
    {
        [Test]
        public async Task GetUnitDataSetsQuery_Should_Retrieve_Unit_DataSets()
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

            // Act
            var unitDataSetsQuery = new GetUnitDataSetsQuery();
            var result = await SendAsync(unitDataSetsQuery);

            // Assert
            result.UnitDataSets.Count.Should().BeGreaterThan(0);
            result.UnitDataSets.Where((u) => u.Id == unitDataSetId).Count().Should().Be(1);
        }
    }
}
