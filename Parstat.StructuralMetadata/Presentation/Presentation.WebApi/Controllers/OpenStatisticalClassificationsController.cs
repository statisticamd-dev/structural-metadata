using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails;
using Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassifications;

namespace Presentation.WebApi.Controllers
{
    public class OpenStatisticalClassificationsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationsVm>> GetAll() => Ok(await Mediator.Send(new GetStatisticalClassificationsQuery()));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationVm>> Get(long id) => Ok(await Mediator.Send(new GetStatisticalClassificationQuery {Id = id}));
    }
}