using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.AddLevelCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.CreateCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.RemoveLevelCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.UpdateCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadItemsCommand;

namespace Presentation.WebApi.Controllers
{
    public class ClosedStatisticalClassificationsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateStatisticalClassificationCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("levels/add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddLevel([FromBody] AddStatisticalClassificationLevelCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateStatisticalClassificationCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UploadData([FromBody] UploadStatisticalClassificationItemsCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{statisticalClassificationId}/levels/remove/{levelId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveLevel([FromBody] long statisticalClassificationId, long levelId)
        {
            return Ok(await Mediator.Send(new RemoveStatisticalClassificationLevelCommand 
                                                { 
                                                    StatisticalClassificationId = statisticalClassificationId,
                                                    LevelId = levelId
                                                }));
        }
    }
}