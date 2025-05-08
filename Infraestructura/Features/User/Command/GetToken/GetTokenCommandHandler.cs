using Infraestructura.Contracts;
using Infraestructura.Models;
using Infraestructura.Utils;
using Infrastucture.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Features.User.Command.GetToken
{
    public class GetTokenCommandHandler : IRequestHandler<GetTokenCommand, ApiResponse<Session>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<Session>> Handle(GetTokenCommand request, CancellationToken cancellationToken)
        {
            bool success = false;
            string Message = "";
            string Token = "";
            string CodeResult = "";
            Session session = null;

            try
            {
                var login = await _unitOfWork.usuariosRepository.GetToken(request.Email, request.Password);

                session = new Session();
                if (login)
                {
                    var user = await _unitOfWork.usuariosRepository.GetByEmail(request.Email);

                    session = new Session();
                    session.Email = request.Email;
                    session.Rol = user.Rol;
                    session.Token = Utils.Security.GenerateToken();
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "No se pudo generar el Token";
                    session = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                session = null;
                success = false;
            }

            ApiResponse<Session> response = new ApiResponse<Session>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = session,
                Success = success
            };

            return response;
        }
    }
}
