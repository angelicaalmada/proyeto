using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Proyeto.Models;

public  class UsuarioModel
{
    [Required(ErrorMessage = "Ingrese Nombre de Usuario")]
    [DisplayName("Nombre de Usuario")]
    public string NombreUsuario { get; set; } = null!;
    [DisplayName("correo electronico")]
    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? IdAutor1 { get; set; }

    public int? Rol { get; set; }



    public virtual AutorModel? Autor { get; set; }
}
