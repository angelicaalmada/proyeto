using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;

namespace Proyeto.datos
{
    public class TipoCuentaDatos
    {
        public List<TipoCuentaModel> Listar()
        {
            List<TipoCuentaModel> Lista = new List<TipoCuentaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_TipoCuentaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new TipoCuentaModel
                        {
                            IdTipo = Convert.ToInt32(dr["IdTipoCuenta"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            //Tipo = dr["Tipo"].ToString(),
                        });
                    }
                }
            }
            return Lista;
        }




        public TipoCuentaModel Obtener(int IdTipo)
        {
            TipoCuentaModel _categoria = new TipoCuentaModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_TipoCuentaObtener", conexion);
                cmd.Parameters.AddWithValue("IdTipoCuenta", IdTipo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _categoria.IdTipo = Convert.ToInt32(dr["IdTipoCuenta"]);
                        _categoria.Descripcion = dr["Descripcion"].ToString();
                    }
                }
            }
            return _categoria;
        }



        public bool Guardar(TipoCuentaModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_TipoCuentaGuardar", conexion);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);                   
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


        public bool Editar(TipoCuentaModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_TipoCuentaEditar", conexion);
                    cmd.Parameters.AddWithValue("IdTipoCuenta", model.IdTipo);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
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



        public bool Eliminar(int IdTipo)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_TipoCuentaEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdTipoCuenta", IdTipo);
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
