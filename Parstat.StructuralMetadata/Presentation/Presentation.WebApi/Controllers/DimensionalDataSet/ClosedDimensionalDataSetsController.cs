using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataSets.DimansionalDataSet.Commands.CreateCommand;

namespace Presentation.WebApi.Controllers.DimensionalDataSet
{
    public class ClosedDimensionalDataSetsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateDimensionalDataSetCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }
    }
}
