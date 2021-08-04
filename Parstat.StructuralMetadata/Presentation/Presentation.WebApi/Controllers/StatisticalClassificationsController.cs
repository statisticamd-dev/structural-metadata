using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassifications;

namespace Presentation.WebApi.Controllers
{
    public class StatisticalClassificationsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationsVm>> GetAll() => Ok(await Mediator.Send(new GetStatisticalClassificationsQuery()));
    }
}