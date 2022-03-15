using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.RepresentedVariables.Commands.CreateRepresentedVariable;

namespace Presentation.WebApi.Controllers.RepresentationVariable
{
    public class ClosedRepresentationVariableController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateRepresentationVariableCommand command, string language)
        {
            command.Language = language;
            var id =  await Mediator.Send(command);

            return Ok(id);
        }       
       

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateRepresentationVariableCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }       
    }
}