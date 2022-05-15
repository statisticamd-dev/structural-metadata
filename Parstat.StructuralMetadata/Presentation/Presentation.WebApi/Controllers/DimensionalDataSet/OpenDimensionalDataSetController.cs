using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataSets.DimansionalDataSet.Queries.GetDimensionalDataSet;
using Presentation.Application.DataSets.DimansionalDataSet.Queries.GetDimensionalDataSetDetails;
using Presentation.Application.DataSets.DimensionalDataSet.Queries.GetDimensionalDataSets;

namespace Presentation.WebApi.Controllers.DimensionalDataSet
{
    public class OpenDimensionalDataSetController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(DimensionalDataSetsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<DimensionalDataSetsVm>> GetAll(string language) => Ok(await Mediator.Send(new GetDimensionalDataSetsQuery { Language = language }));
        
        [HttpGet]
        [Route("detailed/{id}")]
        [ProducesResponseType(typeof(DimensionalDataSetDetailsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<DimensionalDataSetDetailsVm>> GetDetailed(long id, string language) => Ok(await Mediator.Send(new GetDimensionalDataSetDetailsQuery { Id = id, Language = language }));

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DimensionalDataSetVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<DimensionalDataSetVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetDimensionalDataSetQuery { Id = id, Language = language }));
    }
}
