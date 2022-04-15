using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails;
using Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSets;

namespace Presentation.WebApi.Controllers.UnitDataSet
{
    public class OpenUnitDataSetController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(UnitDataSetsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitDataSetsVm>> GetAll(string language) => Ok(await Mediator.Send(new GetUnitDataSetsQuery { Language = language }));

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(UnitDataSetVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitDataSetVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetUnitDataSetDetailsQuery { Id = id, Language = language }));
    }
}
