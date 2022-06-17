using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.MeasurementUnits.Commands.CreateMeasurementUnit;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Test.MeasurementUnits.Commands.CreateMeasurementUnit
{
    using static Testing;
    public class CreateMeasurementUnits
    {
        [Test]
        public async Task CreateMeasurementUnits_Should_Create_MeasurementUnit()
        {
            //Arrange
            var measurementType = new MeasurementType
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Measurement type name"),
                Description = MultilanguageString.Init(Language.EN, "Measurement type description"),
                Version = "1.0",
                VersionDate = DateTime.Now,
            };

            MeasurementType measurementTypeResponse = await AddAsync(measurementType);

            var createMeasurementUnitCommand = new CreateMeasurementUnitCommand
            {
                MeasurementTypeId = measurementTypeResponse.Id,
                LocalId = Guid.NewGuid().ToString(),
                Name = "Measurement unit name",
                Description = "Measurement unit description",
                Version = "1.0",
                VersionDate = DateTime.Now,
                IsStandard = false
            };

            //Act
            long id = await SendAsync(createMeasurementUnitCommand);
            

            //Asserts
            id.Should().BeGreaterThan(0);
        }
    }
}
