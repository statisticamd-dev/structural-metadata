using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructures;

namespace Presentation.WebApi.Controllers.DataStructure
{
    public class OpenUnitDataStructuresController : BaseController
    {
        
        [HttpGet]
        [ProducesResponseType(typeof(UnitDataStructuresVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitDataStructuresVm>> GetAll(string name, string language) 
        {
            return Ok(await Mediator.Send(new GetUnitDataStructuresQuery {Name = name, Language = language }));
        } 

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UnitDataStructureVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitDataStructureVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetUnitDataStructureQuery {Id = id, Language = language }));
    }
}
