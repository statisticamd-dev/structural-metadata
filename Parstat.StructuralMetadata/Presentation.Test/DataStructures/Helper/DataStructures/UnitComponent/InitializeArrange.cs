using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using Presentation.Domain;
using System;
using System.Threading.Tasks;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System.Diagnostics;

namespace Presentation.Test.DataStructures.Helper.DataStructures.UnitComponent
{
    using static Testing;
    public class UnitComponent
    {
        public static async Task<(long dataStructureResponseId, long representedVariableResponseId, long logicalRecordResponseId)> InitializeReferences()
        {
            var dataStructure = new DataStructure
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Data structure name"),
                Description = MultilanguageString.Init(Language.EN, "Description of data structure"),
                Version = "1.0",
                Group = "Data structure group",
                VersionDate = DateTime.Now
            };

            var nodeSet = new NodeSet
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Node set name"),
                Description = MultilanguageString.Init(Language.EN, "Node set description"),
                Version = "1.0",
                VersionDate = DateTime.Now
            };

            var nodeSetResponse = await AddAsync(nodeSet);

            var level = new Level
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Level name"),
                Description = MultilanguageString.Init(Language.EN, "Level description"),
                Version = "1.0",
                VersionDate = DateTime.Now,
                NodeSetId = nodeSetResponse.Id
            };

            var levelResponse = await AddAsync(level);

            var valueDomain = new ValueDomain
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Value domain name"),
                Description = MultilanguageString.Init(Language.EN, "Value domain description"),
                Version = "1.0",
                VersionDate = DateTime.Now,
                LevelId = levelResponse.Id,
                NodeSetId = nodeSetResponse.Id
            };
            ValueDomain valueDomainResponse = await AddAsync(valueDomain);

            var unitType = new UnitType
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Unit Type name"),
                Description = MultilanguageString.Init(Language.EN, "Unit Type description"),
                Version = "1.0",
                VersionDate = DateTime.Now
            };

            UnitType unitTypeResponse = await AddAsync(unitType);

            var variable = new Variable
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Variable name"),
                Description = MultilanguageString.Init(Language.EN, "Variable description"),
                Version = "1.0",
                VersionDate = DateTime.Now,
                MeasuresId = unitTypeResponse.Id
            };
            Variable variableResponse = await AddAsync(variable);

            var representedVariable = new RepresentedVariable
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Represented variable name"),
                Description = MultilanguageString.Init(Language.EN, "Represented variable description"),
                Version = "1.0",
                VersionDate = DateTime.Now,
                SubstantiveValueDomainId = valueDomainResponse.Id,
                VariableId = variableResponse.Id
            };

            DataStructure dataStructureResponse = await AddAsync(dataStructure);
            RepresentedVariable representedVariableResponse = await AddAsync(representedVariable);

            var logicalRecord = new LogicalRecord
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Data structure name"),
                Description = MultilanguageString.Init(Language.EN, "Description of data structure"),
                Version = "1.0",
                DataStructureId = dataStructureResponse.Id,
                UnitTypeId = unitTypeResponse.Id
            };

            LogicalRecord logicalRecordResponse = await AddAsync(logicalRecord);

            (long dataStructureResponseId, long representedVariableResponseId, long logicalRecordResponseId) initializationId = (dataStructureResponse.Id, representedVariableResponse.Id, logicalRecordResponse.Id);
            return initializationId;
        }
    }
}
