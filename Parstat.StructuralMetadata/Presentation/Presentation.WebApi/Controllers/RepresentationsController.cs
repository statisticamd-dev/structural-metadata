using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails;
using Presentation.Application.RepresentedVariables.Queries.GetRepresentedVariablesQuery;

namespace Presentation.WebApi.Controllers
{
    public class RepresentationsController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RepresentedVariableVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetRepresentedVariableQuery {Id = id, Language = language}));

        [HttpGet("variables/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RepresentedVariablesVm>> GetRepresentationsByVariable(long id, string language) => Ok(await Mediator.Send(new GetRepresentedVariablesQuery {VariableId = id, Language = language}));
    }
}