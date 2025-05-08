using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models
{
    public class Session
    {
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string Rol { get; set; } = null!;

    }
}
