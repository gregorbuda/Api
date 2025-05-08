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

namespace Infraestructura.Features.User.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResponse<string>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Usuario user = null;
            string userId = null;
            bool success = false;
            string Message = "";
            string CodeResult = "";

            try
            {

                user = new Usuario();

                user.Id = Guid.NewGuid().ToString();
                user.UserName = request.UserName;
                user.Rol = request.Rol;
                user.Password = Encriptacion.EncodePasswordToBase64(request.Password);
                user.Email = request.Email;

                user = await _unitOfWork.usuariosRepository.AddAsync(user);

                if (user.Id != null)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    userId = user.Id;
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "No se pudo registrar el User";
                    userId = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                userId = null;
                success = false;
            }

            ApiResponse<string> response = new ApiResponse<string>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = userId,
                Success = success
            };

            return response;
        }
    }
}
