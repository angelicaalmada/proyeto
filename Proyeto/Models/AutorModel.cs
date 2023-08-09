using System;
using System.Collections.Generic;

namespace Proyeto.Models;

public partial class AutorModel
{
    public int IdAutor { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApePaterno { get; set; } = null!;

    public string? ApeMaterno { get; set; }

    public int? Matricula { get; set; }

    public int? NumEmpleado { get; set; }

    public string? TipoCuenta { get; set; }

    public string? NumTelefono { get; set; }

    public DateTime? FechaNaci { get; set; }

    public string? CuerpoAcademico { get; set; }

    public string? AreaEstudios { get; set; }

    public int? IdNivelEstudios1 { get; set; }

    public virtual NivelEstudioModel? NivelEstudios1 { get; set; }

}
