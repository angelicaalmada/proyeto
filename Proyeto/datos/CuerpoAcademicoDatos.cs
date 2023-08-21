using Proyeto.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyeto.datos
{
    public class CuerpoAcademicoDatos
    {
        public List<CuerpoAcademicoModel> Listar()
        {
            List<CuerpoAcademicoModel> Lista = new List<CuerpoAcademicoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_CuerpoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new CuerpoAcademicoModel
                        {
                            IdCuerpo = Convert.ToInt32(dr["IdCuerpo"]),
                            NombreCuerpo = dr["NombreCuerpoAcademico"].ToString()

                        });
                    }
                }
            }
            return Lista;
        }


        public CuerpoAcademicoModel Obtener(int IdCuerpo)
        {
            CuerpoAcademicoModel _cuerpo = new CuerpoAcademicoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_CuerpoObtener", conexion);
                cmd.Parameters.AddWithValue("IdCuerpo", IdCuerpo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _cuerpo.IdCuerpo = Convert.ToInt32(dr["IdCuerpo"]);
                        _cuerpo.NombreCuerpo = dr["NombreCuerpoAcademico"].ToString();
                    }
                }
            }
            return _cuerpo;
        }



        public bool Guardar(CuerpoAcademicoModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CuerpoGuardar", conexion);
                    cmd.Parameters.AddWithValue("NombreCuerpoAcademico", model.NombreCuerpo);
   
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


        public bool Editar(CuerpoAcademicoModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CuerpoEditar", conexion);
                    cmd.Parameters.AddWithValue("IdCuerpo", model.IdCuerpo);
                    cmd.Parameters.AddWithValue("NombreCuerpoAcademico", model.NombreCuerpo);
             
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



        public bool Eliminar(int IdCuerpo)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CuerpoEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdCuerpo", IdCuerpo);
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
