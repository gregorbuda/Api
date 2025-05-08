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
    public class RepeatUserByEmailHandler : IRequestHandler<RepeatUserByEmail, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepeatUserByEmailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(RepeatUserByEmail request, CancellationToken cancellationToken)
        {
            bool success = false;
            string Message = "";
            Usuario user = null;
            string CodeResult = "";

            try
            {
                user = await _unitOfWork.usuariosRepository.GetByEmail(request._email);

                if (user.Id != "")
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"User Id {request._email} Not Found";
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

            ApiResponse<bool> response = new ApiResponse<bool>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = success,
                Success = success
            };

            return response;
        }
    }
}
