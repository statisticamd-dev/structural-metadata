using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Correspondences.Queries.GetCorrespondence;
using Presentation.Application.Correspondences.Queries.GetCorrespondences;

namespace Presentation.WebApi.Controllers
{
    public class OpenCorrespondenceController : BaseController
    {
        [HttpGet("/nodeset/{nodesetId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CorrespondencesVm>> GetAllByNodeset(long nodesetId, string language) => Ok(await Mediator.Send(new GetNodesetCorrespondencesQuery {NodeSetId = nodesetId, Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CorrespondenceVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetCorrespondenceQuery {Id = id, Language = language}));
    }
}