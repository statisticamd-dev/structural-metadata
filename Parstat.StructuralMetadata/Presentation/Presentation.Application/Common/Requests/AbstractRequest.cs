using Presentation.Application.Common.Requests.Interfaces;

namespace Presentation.Application.Common.Requests
{
    public class AbstractRequest : IReq
    {
        public string Language { get; set; }
    }
}