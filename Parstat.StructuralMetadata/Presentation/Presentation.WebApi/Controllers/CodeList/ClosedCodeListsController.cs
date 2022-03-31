using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NodeSets.CodeList.Commands.RemoveCodeItemCommand;
using Presentation.Application.NodeSets.CodeLists.Commands.AddCodeItemCommand;
using Presentation.Application.NodeSets.CodeLists.Commands.CreateCommand;
using Presentation.Application.NodeSets.CodeLists.Commands.DeleteCommand;

namespace Presentation.WebApi.Controllers
{
    public class ClosedCodeListsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateCodeListCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("codeitems/add")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddCodeItem([FromBody] AddCodeItemCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromBody] long id)
        {            
            return Ok(await Mediator.Send(new DeleteCodeListCommand { Id = id }));
        }

        [HttpDelete("codeitems/remove")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromBody] RemoveCodeItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}