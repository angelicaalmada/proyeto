using System.ComponentModel;

namespace Proyeto.Models
{
    public class EstudiosRealizadosModel
    {
        [DisplayName("Estudios Realizados")]
        public int IdEstudiosRealizados { get; set; }
        [DisplayName("Matricula o Numero de Empleado")]
        public int Matri_NoEmpl { get; set; }
        [DisplayName("Nombre del Curso")]
        public string NombreCurso { get; set; }
        public string Duracion { get; set; }
        public string Institucion { get; set; } 
        public string Descripcion { get; set; }
        public string? UrlDocumento { get; set; } 
        public int IdAutor1 { get; set; }
        [DisplayName("Autor")]
        public virtual AutorModel? Autor1 { get; set; }
    }
}
