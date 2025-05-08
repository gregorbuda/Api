using Infraestructura.Models;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Features.User.Queries
{
    public class RepeatUserByEmail : IRequest<ApiResponse<bool>>
    {
        /// <summary>
        /// Users Id
        /// </summary>
        /// <value>
        /// Users Id
        /// </value>
        /// <example>1</example>

        public string _email { get; set; }

        public RepeatUserByEmail(string Email)
        {
            _email = Email;
        }
    }
}
