using System;
using System.Collections.Generic;

namespace Proyeto.Models;

public partial class DocumentoModel
{
    public int IdDocumento { get; set; }

    public string Estatus { get; set; } = null!;

    public string? CoAutor { get; set; }

    public int? IdCategoria1 { get; set; }

    public string Urldocumento { get; set; } = null!;


    public virtual TipoCuentaModel? Categoria { get; set; }
}
