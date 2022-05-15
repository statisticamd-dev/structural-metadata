using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.Commands.AddRecord;
using Presentation.Application.DataStructures.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Query.ReadLogicalRecords
{
    using static Testing;
    public class GetLogicalRecord
    {
        [Test]
        public async Task GetDataStructuresQuery_Read_Logical_Record_Details()
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
            var getDataStructureQuery = new GetDataStructureQuery
            {
                Id = dataStructureResponse.Id
            };

            var dataStructureQueryResult = await SendAsync(getDataStructureQuery);
            var result = dataStructureQueryResult.DataStructure.Records.Where((x) => x.Id == logicalRecord).FirstOrDefault();

            // Assert
            result.Should().NotBeNull(); //ensure id is the same 
            result.Should().Be(recordCommand);
        }
    }
}
