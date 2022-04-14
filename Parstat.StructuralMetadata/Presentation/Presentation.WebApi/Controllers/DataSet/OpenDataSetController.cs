using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataSets.Queries.GetDataSets;

namespace Presentation.WebApi.Controllers.DataSet
{
    public class OpenDataSetController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(DataSetsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<DataSetsVm>> GetAll(string language) => Ok(await Mediator.Send(new GetDataSetsQuery { Language = language }));
    }
}
