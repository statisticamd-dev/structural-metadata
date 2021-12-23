using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.ValueDomains.Queries.GetValueDomains;

namespace Presentation.WebApi.Controllers.ValueDomain
{
    public class OpenValueDomainController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ValueDomainVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<ValueDomainVm>> GetAll(string language) => Ok(await Mediator.Send(new GetValueDomainsQuery {Language = language}));
    }
}