using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Concepts.Commands.CreateConcept;
using Presentation.Application.Concepts.Commands.DeleteConcept;
using Presentation.Application.Concepts.Commands.UpdateConcept;

namespace Presentation.WebApi.Controllers.Concept
{
    public class ClosedConceptController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateConceptCommand command, string language)
        {
            command.Language = language;
            var id =  await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateConceptCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteConceptCommand {Id = id}));
        }
    }
}
