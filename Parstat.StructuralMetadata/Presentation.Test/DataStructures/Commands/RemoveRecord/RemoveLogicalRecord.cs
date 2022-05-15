using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.Commands.AddRecord;
using Presentation.Application.DataStructures.Commands.RemoveRecord;
using Presentation.Application.DataStructures.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Commands.RemoveRecord
{
    using static Testing;
    public class RemoveLogicalRecord
    {
        [Test]
        public async Task RemoveRecordCommand()
        {
            // Arrange

            //add data structure
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

             var unitType = new UnitType
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Person"),
                Description = MultilanguageString.Init(Language.EN, "Description of person"),
                Version = "1.0",
                VersionDate = DateTime.Now
            };
            UnitType unitTypeResponse = await AddAsync(unitType);
            
            // add logical record and assign datastructure id
            var newRecord = new LogicalRecord
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Record Name"),
                Description = MultilanguageString.Init(Language.EN, "Record desc"),
                Version = "1.0",
                VersionDate = DateTime.Now,
                DataStructureId = dataStructureResponse.Id,
                UnitTypeId = unitTypeResponse.Id
            };

            LogicalRecord logicalRecordResponse = await AddAsync(newRecord);

            // Act
            var removeRecordCommand = new RemoveRecordCommand
            {
                DataStructureId = dataStructureResponse.Id,
                RecordId = logicalRecordResponse.Id
            };

            await SendAsync(removeRecordCommand);

            //retrieve data structure data
            var getDataStructureQuery = new GetDataStructureQuery
            {
                Id = dataStructureResponse.Id
            };

            var result = await SendAsync(getDataStructureQuery);

            // Assert
            result.DataStructure.Id.Should().Be(dataStructureResponse.Id); //ensure id is the same 
            result.DataStructure.Records.Where((x) => x.Id == logicalRecordResponse.Id).Should().HaveCount(0); // ensure that the added logical record is not part of the list
        }
    }
}
