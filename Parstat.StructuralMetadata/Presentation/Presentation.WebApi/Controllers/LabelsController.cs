using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Labels.Commands.CreateLabel;
using Presentation.Application.Labels.Commands.UpdateLabel;
using Presentation.Application.Labels.Queries.GetLabes;

namespace Presentation.WebApi.Controllers
{
    public class LabelsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LabelsVm>> GetAll(string language, string value) => Ok(await Mediator.Send(new GetLabelsQuery {Language = language, Value = value}));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateLabelCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateLabelCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }
    }
}