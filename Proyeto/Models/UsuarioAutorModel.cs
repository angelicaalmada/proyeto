using System.ComponentModel;

namespace Proyeto.Models
{
    public class UsuarioAutorModel
    {
        public int IdAutor { get; set; }

        public string Nombre { get; set; }
        [DisplayName("Apellido Paterno")]
        public string ApePaterno { get; set; }
        [DisplayName("Apellido Materno")]
        public string ApeMaterno { get; set; }

        public int Matricula { get; set; }
        [DisplayName("Numero de Empleado")]
        public int NumEmpleado { get; set; }
        //[DisplayName("Tipo de cuenta")]
        //public string TipoCuenta { get; set; }
        [DisplayName("Numero de Telefono")]
        public string NumTelefono { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        public DateTime FechaNaci { get; set; }
        [DisplayName("Cuerpo Academico")]
        public string CuerpoAcademico { get; set; }
        [DisplayName("Area de Estudios")]
        public string AreaEstudios { get; set; }
        [DisplayName("Nivel de Estudios")]
        public string NivelEstudio { get; set; }
        [DisplayName("Nombre d eUsuario")]
        public string NombreUsuario { get; set; }

        public string Correo { get; set; }
    }
}
