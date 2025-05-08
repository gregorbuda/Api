using Infraestructura.Contracts;
using Infraestructura.Models;
using Infrastucture.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Features.User.Queries
{
    public class GetUserIdByIdHandler : IRequestHandler<GetUserIdById, ApiResponse<Usuario>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserIdByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<Usuario>> Handle(GetUserIdById request, CancellationToken cancellationToken)
        {
            bool success = false;
            string Message = "";
            Usuario user = null;
            string CodeResult = "";

            try
            {
                user = await _unitOfWork.usuariosRepository.GetById(request._usersId);

                if (user != null)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"User Id {request._usersId} Not Found";
                    user = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                user = user;
                success = false;
            }

            ApiResponse<Usuario> response = new ApiResponse<Usuario>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = user,
                Success = success
            };

            return response;
        }

    }
}
