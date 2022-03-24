using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails;
using Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetStatisticalClassifications;

namespace Presentation.WebApi.Controllers
{
    public class OpenStatisticalClassificationsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(StatisticalClassificationsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationsVm>> GetAll(string language) => Ok(await Mediator.Send(new GetStatisticalClassificationsQuery() {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StatisticalClassificationVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetStatisticalClassificationQuery {Id = id, Language = language}));
    }
}