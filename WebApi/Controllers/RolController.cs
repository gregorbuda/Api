using Infraestructura.Features.Roles.Queries;
using Infraestructura.Features.User.Queries;
using Infraestructura.Models;
using Infrastucture.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebAPI.Utils;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetailsNotFound), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetailsNotAcceptable), (int)HttpStatusCode.NotAcceptable)]
    [ProducesResponseType(typeof(ProblemDetailsInternalServerError), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetailsUnauthorized), (int)HttpStatusCode.Unauthorized)]
    [SwaggerTag("The Usuario Type REST services")]
    public class RolController : ControllerBaseCustom
    {

        private readonly IMediator _mediator;

        public RolController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <param name="">.</param>
        /// <returns>
        /// Get All Roles
        /// </returns>
        /// <remarks>
        /// Get All Roles
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<Role>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Role>>> GetAll()
        {
            var query = new GetAllRol();
            var list = await _mediator.Send(query);
            return Ok(list);
        }
    }
}
