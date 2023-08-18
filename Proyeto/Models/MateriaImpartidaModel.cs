using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyeto.Models
{
    public class MateriaImpartidaModel
    {
        public int IdMateria { get; set; }
        public int Matricula { get; set;}
        public int IdCarrera { get; set;}
        public CarreraAdminModel? CarreraModel { get; set; }
        public int IdMateriaAdmin { get; set;}
        public AdminMateriaModel? MateriaAdmin { get; set; }
        public string Grupo { get; set;}
        public string FechaCuatri { get; set;}
        public string? UrlDocumento { get; set;}
        public int IdAutor1 { get; set;}

    }
}
