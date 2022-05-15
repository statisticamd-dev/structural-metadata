using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataStructures.Queries.GetDataStructureDetails;
using Presentation.Application.DataStructures.Queries.GetDataStructures;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.WebApi.Controllers.DataStructure
{
    public class OpenDataStructuresController : BaseController
    {
        
        [HttpGet]
        [ProducesResponseType(typeof(DataStructuresVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<DataStructuresVm>> GetAll(string name, string type, string language) 
        {
            DataSetType dsType;
            if (String.IsNullOrEmpty(type) || !Enum.TryParse<DataSetType>(type, true, out dsType))
            {
                dsType = DataSetType.UNIT; //default
            }
            return Ok(await Mediator.Send(new GetDataStructuresQuery {Name = name, Type = dsType, Language = language }));
        } 

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DataStructureVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<DataStructureVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetDataStructureQuery {Id = id, Language = language }));
    }
}
