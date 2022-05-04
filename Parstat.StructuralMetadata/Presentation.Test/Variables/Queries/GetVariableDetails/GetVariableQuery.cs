using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.Variables.Queries.GetVariableDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading.Tasks;

namespace Presentation.Test.Variables.Queries.GetVariableDetails
{
    using static Testing;
    public class GetVariableTest
    {
        [Test]
        public async Task GetVariableQuery_ShouldReturnTheVariableDetails()
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

            // Arrange
            var query = new GetVariableQuery();
            VariableVm result = await SendAsync(query);

            // Act
            result.Should().NotBeNull();
        }
    }
}
