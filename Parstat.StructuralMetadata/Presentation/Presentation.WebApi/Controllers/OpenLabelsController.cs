using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Labels.Commands.CreateLabel;
using Presentation.Application.Labels.Commands.UpdateLabel;
using Presentation.Application.Labels.Queries.GetLabes;

namespace Presentation.WebApi.Controllers
{
    public class OpenLabelsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(LabelsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<LabelsVm>> GetAll(string language, string value) => Ok(await Mediator.Send(new GetLabelsQuery {Language = language, Value = value}));

    
    }
}