using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataStructures.Queries.GetDataStructures;

namespace Presentation.WebApi.Controllers.DataStructure
{
    public class OpenDataStructuresController : BaseController
    {
        
        [HttpGet]
        [ProducesResponseType(typeof(DataStructuresVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<DataStructuresVm>> GetAll(string name, string language) => Ok(await Mediator.Send(new GetDataStructuresQuery {Name = name, Language = language }));
    }
}
