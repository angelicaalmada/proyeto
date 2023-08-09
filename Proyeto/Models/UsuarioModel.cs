using System;
using System.Collections.Generic;

namespace Proyeto.Models;

public partial class UsuarioModel
{
    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? IdAutor1 { get; set; }

   

    public virtual AutorModel? Autor { get; set; }
}
