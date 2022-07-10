using CustomerSupport.Application.CustomerInquiry.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CustomerSupport.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class CustomerInquiryController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        /// <summary>
        /// Create new Inquiry.
        /// </summary>
        /// <param name="command">customer inquiry command</param>
        /// <returns>key - requestId</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("/api/customerInquiry")]
        public async Task<ActionResult<Guid>> Post(CreateCustomerInquiryCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}