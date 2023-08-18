using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyeto.Models;

public partial class AutorModel
{
    public int IdAutor { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Apellido Paterno")]
    public string ApePaterno { get; set; } = null!;
    [DisplayName("Apellido Materno")]
    public string? ApeMaterno { get; set; }

    public int? Matricula { get; set; }
    [DisplayName("Numero de Empleado")]
    public int? NumEmpleado { get; set; }
    [DisplayName("Tipo de Cuenta")]
    public int? IdTipoCuenta { get; set; }
    [DisplayName("Tipo de Cuenta")]
    public TipoCuentaModel? TipoCuenta { get; set; }

    [DisplayName("Numero de Telefono")]
    public string? NumTelefono { get; set; }
    [DisplayName("Fecha de Nacimiento")]
    public DateTime? FechaNaci { get; set; }
    [DisplayName("Cuerpo Academico")]
    public string? CuerpoAcademico { get; set; }
    [DisplayName("Area de Estudios")]
    public string? AreaEstudios { get; set; }

    [DisplayName("Nivel de Estudios")]
    public int? IdNivelEstudios1 { get; set; }
    [DisplayName("Nivel de Estudios")]
    public virtual NivelEstudioModel? NivelEstudios1 { get; set; }

}
