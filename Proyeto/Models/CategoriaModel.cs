using System;
using System.Collections.Generic;

namespace Proyeto.Models;

public partial class CategoriaModel
{
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

}
