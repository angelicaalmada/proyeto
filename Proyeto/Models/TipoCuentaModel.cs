using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyeto.Models;

public partial class TipoCuentaModel
{
   
    public int IdTipo { get; set; }

    public string Descripcion { get; set; } = null!;

    //public string Tipo { get; set; } = null!;

}
