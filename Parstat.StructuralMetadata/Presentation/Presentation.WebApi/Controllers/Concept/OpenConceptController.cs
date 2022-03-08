using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Concepts.Queries.GetConceptDetails;
using Presentation.Application.Concepts.Queries.GetConcepts;

namespace Presentation.WebApi.Controllers.Concept
{
    public class OpenConceptController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ConceptsVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<ConceptsVm>> GetAll(string language) => Ok(await Mediator.Send(new GetConceptsQuery { Language = language }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConceptVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<ConceptVm>> GetById(long id, string language) => Ok(await Mediator.Send(new GetConceptQuery { Id = id, Language = language }));
    }
}
