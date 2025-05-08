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
    public class GetUserIdById : IRequest<ApiResponse<Usuario>>
    {
        /// <summary>
        /// Users Id
        /// </summary>
        /// <value>
        /// Users Id
        /// </value>
        /// <example>1</example>

        public string _usersId { get; set; }

        public GetUserIdById(string UsersId)
        {
            _usersId = UsersId;
        }
    }
}
