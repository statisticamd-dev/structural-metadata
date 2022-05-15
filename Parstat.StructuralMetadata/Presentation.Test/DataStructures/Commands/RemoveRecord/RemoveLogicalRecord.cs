using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.Commands.AddRecord;
using Presentation.Application.DataStructures.Commands.RemoveRecord;
using Presentation.Application.DataStructures.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
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
        public async Task GetDataStructuresQuery_Read_All_Logical_Records()
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

            // add logical record and assign datastructure id
            var recordCommand = new AddRecordCommand
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = "Logical record name",
                Description = "Logical record description",
                Version = "1.0",
                VersionDate = DateTime.Now,
                DataStructureId = dataStructureResponse.Id
            };

            long logicalRecord = await SendAsync(recordCommand);

            // Act
            var removeRecordCommand = new RemoveRecordCommand
            {
                DataStructureId = dataStructureResponse.Id,
                RecordId = logicalRecord
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
            result.DataStructure.Records.Where((x) => x.Id == logicalRecord).Should().HaveCount(0); // ensure that the added logical record is not part of the list
        }
    }
}
