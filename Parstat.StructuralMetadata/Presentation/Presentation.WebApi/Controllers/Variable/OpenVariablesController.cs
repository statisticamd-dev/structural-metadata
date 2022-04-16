using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Variables.Commands.CreteVariable;
using Presentation.Application.Variables.Queries.GetVariableDetails;
using Presentation.Application.Variables.Queries.GetVariableList;

namespace Presentation.WebApi.Controllers
{
    public class OpenVariablesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(VariableListVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<VariableListVm>> GetAll(string language) => Ok(await Mediator.Send(new GetVariableListQuery { Language = language }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VariableVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<VariableVm>> Get(long id) => Ok(await Mediator.Send(new GetVariableQuery { Id = id }));

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(VariableListVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<VariableListVm>> GetByName(string name, string language) => Ok(await Mediator.Send(new GetVariableListQuery { Name = name, Language = language }));
    }
}