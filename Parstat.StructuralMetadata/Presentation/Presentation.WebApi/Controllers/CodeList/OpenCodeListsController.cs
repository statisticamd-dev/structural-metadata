using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NodeSets.CodeLists.Queries.GetCodeListDetails;
using Presentation.Application.NodeSets.CodeLists.Queries.GetCodeLists;

namespace Presentation.WebApi.Controllers
{
    public class OpenCodeListsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(CodeListsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<CodeListsVm>> GetAll(string name, string language) => Ok(await Mediator.Send(new GetCodeListsQuery { Name = name, Language = language }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CodeListVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<CodeListVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetCodeListDetailsQuery { Id = id, Language = language }));

    }
}