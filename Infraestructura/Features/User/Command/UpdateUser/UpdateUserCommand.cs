using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Features.User.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<ApiResponse<bool>>
    {
        public string Id { get; set; } = null!;

        public string Rol { get; set; } = null!;
    }
}
