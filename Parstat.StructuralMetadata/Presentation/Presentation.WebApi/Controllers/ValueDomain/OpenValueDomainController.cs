using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.ValueDomains.Queries.GetValueDomain;
using Presentation.Application.ValueDomains.Queries.GetValueDomains;

namespace Presentation.WebApi.Controllers.ValueDomain
{
    public class OpenValueDomainController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ValueDomainListVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<ValueDomainListVm>> GetAll(string language) => Ok(await Mediator.Send(new GetValueDomainsQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ValueDomainVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<ValueDomainVm>> GetById(long id, string language) => Ok(await Mediator.Send(new GetValueDomainQuery {Id = id, Language = language}));
    }
}