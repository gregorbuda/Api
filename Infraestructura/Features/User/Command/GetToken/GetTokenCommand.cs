using Infraestructura.Models;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Features.User.Command.GetToken
{
    public class GetTokenCommand : IRequest<ApiResponse<Session>>
    {
        /// <summary>
        /// Email User
        /// </summary>
        /// <value>
        /// Email User
        /// </value>
        /// <example>test@test.com</example>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Password User
        /// </summary>
        /// <value>
        /// Password User
        /// </value>
        /// <example></example>
        [Required]
        public string? Password { get; set; }
    }
}
