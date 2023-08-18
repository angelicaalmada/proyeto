using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;

namespace Proyeto.datos
{
    public class UsuarioAutorDatos
    {
        public List<UsuarioAutorModel> Consultar()
        {
            List<UsuarioAutorModel> Lista = new List<UsuarioAutorModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_UsuariosAutorConsultar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new UsuarioAutorModel
                        {
                            IdAutor = Convert.ToInt32(dr["IdAutor"]),
                            Nombre = dr["Nombre"].ToString(),
                            ApePaterno = dr["ApePaterno"].ToString(),
                            ApeMaterno = dr["ApeMaterno"].ToString(),
                            Matricula = dr["Matricula"] != DBNull.Value ? Convert.ToInt32(dr["Matricula"]) : 0,
                            NumEmpleado = dr["NumEmpleado"] != DBNull.Value ? Convert.ToInt32(dr["NumEmpleado"]) : 0,
                           
                            NumTelefono = dr["NumTelefono"].ToString(),
                            FechaNaci = Convert.ToDateTime(dr["FechaNaci"]),
                            CuerpoAcademico = dr["CuerpoAcademico"].ToString(),
                            AreaEstudios = dr["AreaEstudios"].ToString(),
                            NivelEstudio = dr["NombreNivel"].ToString(),
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            //IdNivelEstudios1 = Convert.ToInt32(dr["IdNivelEstudios1"])

                        });
                    }
                }
            }
            return Lista;
        }
    }
}
