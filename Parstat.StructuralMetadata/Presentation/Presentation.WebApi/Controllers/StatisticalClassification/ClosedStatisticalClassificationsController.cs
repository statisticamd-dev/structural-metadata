using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.AddLevelCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.CreateCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.DeleteCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.RemoveLevelCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.UpdateCommand;
using Presentation.Application.NodeSets.StatisticalClassifications.Commands.UpdateLevelCommand;
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
        [Route("levels")]
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
        [Route("{statisticalClassificationId}/levels/{levelId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveLevel(long statisticalClassificationId, long levelId)
        {
            return Ok(await Mediator.Send(new RemoveStatisticalClassificationLevelCommand 
                                                { 
                                                    StatisticalClassificationId = statisticalClassificationId,
                                                    LevelId = levelId
                                                }));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id) 
        {
            return Ok(await Mediator.Send(new DeleteStatisticalClassificationCommand() {Id = id}));
        }

        [HttpPatch]
        [Route("levels")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateLevel([FromBody] UpdateStatisticalClassificationLevelCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }
    }
}