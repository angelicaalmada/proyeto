using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Proyeto.Models
{
    public class HistorialDocModel
    {
        public int IdAutor { get; set; }
        public string TipoDoc { get; set; }
        public int IdDoc { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string NombreDocMat { get; set; }

    }
}
