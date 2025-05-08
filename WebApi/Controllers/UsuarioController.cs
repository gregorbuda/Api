
using Infraestructura.Features.User.Command.CreateUser;
using Infraestructura.Features.User.Command.GetToken;
using Infraestructura.Features.User.Command.UpdateUser;
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
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetailsNotFound), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetailsNotAcceptable), (int)HttpStatusCode.NotAcceptable)]
    [ProducesResponseType(typeof(ProblemDetailsInternalServerError), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetailsUnauthorized), (int)HttpStatusCode.Unauthorized)]
    [SwaggerTag("The Usuario Type REST services")]
    public class UsuarioController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <param name="">.</param>
        /// <returns>
        /// Get All Users
        /// </returns>
        /// <remarks>
        /// Get All Users
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Usuario>>> GetAll()
        {
            var query = new GetAllUsers();
            var list = await _mediator.Send(query);
            return Ok(list);
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <param name="">.</param>
        /// <returns>
        /// Get All Users
        /// </returns>
        /// <remarks>
        /// Get All Users
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("UserById/{Id}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Usuario>>> GetUserById(string Id)
        {
            var query = new GetUserIdById(Id);
            var list = await _mediator.Send(query);
            return Ok(list);
        }

        /// <summary>
        /// Create  User 
        /// </summary>
        /// <param name="command">The data  User .</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// <remarks>
        /// Create  User 
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost()]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<string>>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut()]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<string>>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("GetToken")]
        [ProducesResponseType(typeof(ApiResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<string>>> GetToken([FromBody] GetTokenCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("RepeatByEmail/{Email}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Usuario>>> RepeatByEmail(string Email)
        {
            var query = new RepeatUserByEmail(Email);
            var list = await _mediator.Send(query);
            return Ok(list);
        }
    }
}
