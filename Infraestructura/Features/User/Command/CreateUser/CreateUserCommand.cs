using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Features.User.Command.CreateUser
{
    public class CreateUserCommand : IRequest<ApiResponse<string>>
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Rol { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
