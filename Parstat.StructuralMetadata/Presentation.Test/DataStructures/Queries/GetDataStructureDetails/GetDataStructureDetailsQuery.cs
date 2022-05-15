using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System.Threading.Tasks;
using System;

namespace Presentation.Test.DataStructures.Queries.GetDataStructureDetails
{
    using static Testing;
    public class GetDataStructureDetailsQuery
    {
        [Test]
        public async Task GetDataStructuresQuery_ShouldReturnDataStructure()
        {
            // Arrange
            var dataStructure = new DataStructure
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Variable1"),
                Description = MultilanguageString.Init(Language.EN, "Description of variable 1"),                
                Version = "1.1",
                Group = "Data structure group",
                VersionDate = DateTime.Now,                        
            };
            DataStructure returnedVariable = await AddAsync(dataStructure);

            // Act
            var query = new GetUnitDataStructureQuery
            {
                Id = returnedVariable.Id
            };
            UnitDataStructureVm result = await SendAsync(query);

            // Assert
            result.UnitDataStructure.Id.Should().Be(returnedVariable.Id);
            result.Should().NotBeNull();
        }
    }
}
