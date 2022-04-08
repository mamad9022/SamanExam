using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saman.Test.Backend.Application.Command;
using Saman.Test.Backend.Application.Responses;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Api.Controllers
{
    [Route("[controller]")]
    public class CardTransactionController : BaseController
    {
        public CardTransactionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("CardToCard")]
        public async Task<CardTransactionResponse> CardToCard ([FromBody] CardTransationCommand request)
        {
            return await CommandAsync(request);
        }
    }
}
