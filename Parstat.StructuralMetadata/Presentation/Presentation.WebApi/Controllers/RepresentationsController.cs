using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails;

namespace Presentation.WebApi.Controllers
{
    public class RepresentationsController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RepresentedVariableVm>> Get(long id) => Ok(await Mediator.Send(new GetRepresentedVariableQuery {Id = id}));
    }
}