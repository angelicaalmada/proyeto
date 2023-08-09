using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;

namespace Proyeto.datos
{
    public class CategoriaDatos
    {
        public List<CategoriaModel> Listar()
        {
            List<CategoriaModel> Lista = new List<CategoriaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_CategoriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new CategoriaModel
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Tipo = dr["Tipo"].ToString(),
                        });
                    }
                }
            }
            return Lista;
        }




        public CategoriaModel Obtener(int IdCategoria)
        {
            CategoriaModel _categoria = new CategoriaModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_CategoriaObtener", conexion);
                cmd.Parameters.AddWithValue("IdCategoria", IdCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _categoria.IdCategoria = Convert.ToInt32(dr["IdCategoria"]);
                        _categoria.Descripcion = dr["Descripcion"].ToString();
                        _categoria.Tipo = dr["Tipo"].ToString();
                    }
                }
            }
            return _categoria;
        }



        public bool Guardar(CategoriaModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CategoriaGuardar", conexion);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                    cmd.Parameters.AddWithValue("Tipo", model.Tipo);
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


        public bool Editar(CategoriaModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CategoriaEditar", conexion);
                    cmd.Parameters.AddWithValue("IdCategoria", model.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                    cmd.Parameters.AddWithValue("Tipo", model.Tipo);
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



        public bool Eliminar(int IdCategoria)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CategoriaEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdCategoria", IdCategoria);
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
