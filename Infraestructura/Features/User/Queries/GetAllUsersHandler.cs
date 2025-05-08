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
    class GetAllUsersHandler : IRequestHandler<GetAllUsers, ApiResponse<IReadOnlyList<Usuario>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<ApiResponse<IReadOnlyList<Usuario>>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            bool success = false;
            string Message = "";
            IReadOnlyList<Usuario> userLista = null;
            string CodeResult = "";

            try
            {
                userLista = await _unitOfWork.usuariosRepository.GetAllAsync();

                if (userLista.Count > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Not Found Data";
                    userLista = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                userLista = null;
                success = false;
            }

            ApiResponse<IReadOnlyList<Usuario>> response = new ApiResponse<IReadOnlyList<Usuario>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = userLista,
                Success = success
            };

            return response;
        }
    }
}
