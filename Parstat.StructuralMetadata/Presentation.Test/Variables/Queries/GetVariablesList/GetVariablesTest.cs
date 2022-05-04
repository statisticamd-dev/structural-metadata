using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.Variables.Queries.GetVariableList;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading.Tasks;

namespace Presentation.Test.Variables.Queries.GetVariablesList
{
    using static Testing;

    public class GetVariablesTest
    {
        [Test]
        public async Task GetVariableListQuery_ShouldReturnTheListOfVariables()
        {
            // Arrange
            var variable = new Variable
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Variable1"),
                Description = MultilanguageString.Init(Language.EN, "Description of variable 1"),
                Definition = MultilanguageString.Init(Language.EN, "Definition of variable 1"),
                Version = "1.1",
                Measures = new UnitType
                {
                    Version = "1.0",
                    LocalId = Guid.NewGuid().ToString(),
                    Name = MultilanguageString.Init(Language.EN, "Measures 1"),
                    Description = MultilanguageString.Init(Language.EN, "Measures 1 description"),
                    Definition = MultilanguageString.Init(Language.EN, "Measures 1 definition"),
                }
            };
            await AddAsync(variable);

            // Act
            var query = new GetVariableListQuery();
            VariableListVm result = await SendAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.Variables.Should().HaveCountGreaterThan(0);
        }
    }
}
