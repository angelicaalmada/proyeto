using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;

namespace Proyeto.datos
{
    public class NivelEstudioDatos
    {
        public List<NivelEstudioModel> Listar()
        {
            List<NivelEstudioModel> Lista = new List<NivelEstudioModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_NivelEstudiosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new NivelEstudioModel
                        {
                            NivelEstudiosId = Convert.ToInt32(dr["NivelEstudiosId"]),
                            NombreNivel = dr["NombreNivel"].ToString(),   
                        });
                    }
                }
            }
            return Lista;
        }



        public NivelEstudioModel Obtener(int NivelEstudiosId)
        {
            NivelEstudioModel _nivel = new NivelEstudioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_NivelEstudiosObtener", conexion);
                cmd.Parameters.AddWithValue("NivelEstudiosId", NivelEstudiosId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _nivel.NivelEstudiosId = Convert.ToInt32(dr["NivelEstudiosId"]);
                        _nivel.NombreNivel = dr["NombreNivel"].ToString();

                    }
                }
            }
            return _nivel;
        }



        public bool Guardar(NivelEstudioModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_NivelEstudiosGuardar", conexion);
                    cmd.Parameters.AddWithValue("nombreNivel", model.NombreNivel);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }



        public bool Editar(NivelEstudioModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_NivelEstudiosEditar", conexion);
                    cmd.Parameters.AddWithValue("NivelEstudiosId", model.NivelEstudiosId);
                    cmd.Parameters.AddWithValue("NombreNivel", model.NombreNivel);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }



        public bool Eliminar(int NivelEstudiosId)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_NivelEstudiosEliminar", conexion);
                    cmd.Parameters.AddWithValue("NivelEstudiosId", NivelEstudiosId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }
}
