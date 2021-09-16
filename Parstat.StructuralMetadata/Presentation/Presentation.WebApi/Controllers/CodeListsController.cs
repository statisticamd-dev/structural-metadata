using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NoteSets.CodeLists.Commands.AddCodeItemCommand;
using Presentation.Application.NoteSets.CodeLists.Commands.CreateCommand;
using Presentation.Application.NoteSets.CodeLists.Queries.GetCodeListDetails;
using Presentation.Application.NoteSets.CodeLists.Queries.GetCodeLists;

namespace Presentation.WebApi.Controllers
{
    public class CodeListsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CodeListsVm>> GetAll(string language) => Ok(await Mediator.Send(new GetCodeListsQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CodeListVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetCodeListDetailsQuery {Id = id, Language = language}));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateCodeListCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("codeitems/add")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddCodeItem([FromBody]AddCodeItemCommand command)
        {
            var unit =  await Mediator.Send(command);
            return Ok(unit);
        }

    }
}