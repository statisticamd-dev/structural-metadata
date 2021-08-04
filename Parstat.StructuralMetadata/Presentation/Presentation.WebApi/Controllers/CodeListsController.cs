using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NoteSets.CodeLists.Queries.GetCodeListDetails;
using Presentation.Application.NoteSets.CodeLists.Queries.GetCodeLists;

namespace Presentation.WebApi.Controllers
{
    public class CodeListsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CodeListsVm>> GetAll() => Ok(await Mediator.Send(new GetCodeListsQuery()));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CodeListVm>> Get(long id) => Ok(await Mediator.Send(new GetCodeListDetailsQuery {Id = id}));
    }
}