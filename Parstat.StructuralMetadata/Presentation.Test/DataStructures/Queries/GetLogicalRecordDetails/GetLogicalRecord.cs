using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.AddRecord;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
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
                Name = MultilanguageString.Init(Language.EN, "Record name"),
                Description = MultilanguageString.Init(Language.EN, "Record desc"),
                Version = "1.0",
                VersionDate = DateTime.Now,
                UnitTypeId = unitTypeResponse.Id,
                DataStructureId = dataStructureResponse.Id
            };
            
            
            LogicalRecord logicalRecordResponse = await AddAsync(newRecord);

            // Act
            var getDataStructureQuery = new GetUnitDataStructureQuery
            {
                Id = dataStructureResponse.Id
            };

            var dataStructureQueryResult = await SendAsync(getDataStructureQuery);
            var result = dataStructureQueryResult.UnitDataStructure.Records.Where((x) => x.Id == logicalRecordResponse.Id).FirstOrDefault();

            // Assert
            result.Should().NotBeNull(); //ensure id is the same 
            result.Id.Should().Be(logicalRecordResponse.Id);
        }
    }
}
