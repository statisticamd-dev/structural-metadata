using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetFlatStatisticalClassification;
using Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails;
using Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetStatisticalClassificationLevels;
using Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetStatisticalClassifications;

namespace Presentation.WebApi.Controllers
{
    public class OpenStatisticalClassificationsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(StatisticalClassificationsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationsVm>> GetAll(string name, string language) => Ok(await Mediator.Send(new GetStatisticalClassificationsQuery() { Name = name, Language = language }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StatisticalClassificationVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetStatisticalClassificationQuery { Id = id, Language = language }));

        [HttpGet("flat/{id}")]
        [ProducesResponseType(typeof(StatisticalClassificationFlatVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationFlatVm>> GetFlat(long id, string language) => Ok(await Mediator.Send(new GetFlatStatisticalClassificationQuery { Id = id, Language = language }));

        [HttpGet("{id}/levels")]
        [ProducesResponseType(typeof(StatisticalClassificationLevelsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticalClassificationLevelsVm>> GetLevels(long id, string language) => Ok(await Mediator.Send(new GetStatisticalClassificationLevelsQuery {Id = id, Language = language}));
    }
}