using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Saman.Test.Backend.Domain.Exceptions;
using Saman.Test.Backend.Domain.Common;
using Saman.Test.Backend.Api.Infrastucture;

namespace Saman.Test.Backend.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IMediator _mediator;

        public HttpStatusCode? ResponseHttpStatusCode { get; set; }

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [NonAction]
        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await _mediator.Send(query);
        }

        [NonAction]
        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await _mediator.Send(command);
        }

        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                throw new SamanValidationException(actionContext.ModelState.ToDictionary());
            }
        }

        public override void OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext context)
        {
            var response = context.Result as ObjectResult;

            if (response?.Value == null)
                return;

            context.Result = StatusCode((int)(ResponseHttpStatusCode ?? HttpStatusCode.OK), new Envelop()
            {
                Data = response?.Value
            });
        }
    }
}
