using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Variables.Queries.GetVariableDetails;
using Presentation.Application.Variables.Queries.GetVariableList;

namespace Presentation.WebApi.Controllers
{
    public class VariablesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VariableListVm>> GetAll() => Ok(await Mediator.Send(new GetVariableListQuery()));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VariableListVm>> Get(long id) => Ok(await Mediator.Send(new GetVariableQuery {Id = id}));
    }
}