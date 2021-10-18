using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails;
using Presentation.Application.RepresentedVariables.Queries.GetRepresentedVariablesQuery;

namespace Presentation.WebApi.Controllers
{
    public class OpenRepresentationsController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RepresentedVariableVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<RepresentedVariableVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetRepresentedVariableQuery {Id = id, Language = language}));

        [HttpGet("variables/{id}")]
        [ProducesResponseType(typeof(RepresentedVariablesVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<RepresentedVariablesVm>> GetRepresentationsByVariable(long id, string language) => Ok(await Mediator.Send(new GetRepresentedVariablesQuery {VariableId = id, Language = language}));
    }
}