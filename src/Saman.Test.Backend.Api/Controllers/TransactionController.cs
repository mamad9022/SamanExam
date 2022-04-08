using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saman.Test.Backend.Application.Command;
using Saman.Test.Backend.Application.Query;
using Saman.Test.Backend.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Api.Controllers
{
    [Route("[controller]")]
    public class TransactionController : BaseController
    {
        public TransactionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("List")]
        public async Task<List<TransactionResponse>> GetTransactionList ([FromQuery] TransactionQuery request)
        {
            return await QueryAsync(request);
        }
    }
}
