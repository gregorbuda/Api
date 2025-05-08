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
    public class GetAllUsers : IRequest<ApiResponse<IReadOnlyList<Usuario>>>
    {
    }
}
