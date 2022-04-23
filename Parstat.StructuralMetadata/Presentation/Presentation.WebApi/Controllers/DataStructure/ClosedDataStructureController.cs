using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataSets.DataStructures.Commands;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers
{
    public class ClosedDataStructureController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateDataStructureCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }
      
    }
}
