using Infraestructura.Models;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Features.Roles.Queries
{
    public class GetAllRol : IRequest<ApiResponse<IReadOnlyList<Role>>>
    {
    }
}
