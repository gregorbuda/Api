using System;
using System.Collections.Generic;

namespace Infraestructura.Models;

public partial class Usuario
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Password { get; set; } = null!;
}
