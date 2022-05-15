using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.AddComponent;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.AddRecord;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.CreateCommand;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.DeleteCommand;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.RemoveComponent;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.RemoveRecord;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateCommand;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateComponent;
using Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateRecord;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers
{
    public class ClosedUnitDataStructuresController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateUnitDataStructureCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateUnitDataStructureCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteUnitDataStructureCommand { Id = id }));
        }

        [HttpPut]
        [Route("records")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddLogicalRecord([FromBody] AddRecordCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{dataStructureId}/records/{recordId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteLogicalRecord(long dataStructureId, long recordId)
        {
            return Ok(await Mediator.Send(new RemoveRecordCommand { DataStructureId = dataStructureId, RecordId = recordId }));
        }

        [HttpPatch]
        [Route("records")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PatchLogicalRecord([FromBody] UpdateRecordCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("components")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddComponent([FromBody] AddUnitComponentCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPatch]
        [Route("components")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PatchLogicalRecord([FromBody] UpdateUnitComponentCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{dataStructureId}/records/{componentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteComponent(long dataStructureId, long componentId)
        {
            return Ok(await Mediator.Send(new RemoveUnitComponentCommand { UnitDataStructureId = dataStructureId, UnitComponentId = componentId }));
        }
    }
}
