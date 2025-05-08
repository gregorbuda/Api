using Infraestructura.Contracts;
using Infraestructura.Features.User.Queries;
using Infraestructura.Models;
using Infrastucture.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Features.Roles.Queries
{
    public class GetAllRolHandler : IRequestHandler<GetAllRol, ApiResponse<IReadOnlyList<Role>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRolHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<ApiResponse<IReadOnlyList<Role>>> Handle(GetAllRol request, CancellationToken cancellationToken)
        {
            bool success = false;
            string Message = "";
            IReadOnlyList<Role> userLista = null;
            string CodeResult = "";

            try
            {
                userLista = await _unitOfWork.rolRepository.GetAllAsync();

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

            ApiResponse<IReadOnlyList<Role>> response = new ApiResponse<IReadOnlyList<Role>>
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
