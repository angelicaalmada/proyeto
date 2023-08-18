using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;
namespace Proyeto.datos
{
    public class AdminMateriaDatos
    {
        public List<AdminMateriaModel> Listar()
        {
            List<AdminMateriaModel> Lista = new List<AdminMateriaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AdminMateriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new AdminMateriaModel
                        {
                            IdAdminMateria = Convert.ToInt32(dr["IdAdminMateria"]),
                            NombreMat = dr["NombreMat"].ToString(),
                        });
                    }
                }
            }
            return Lista;
        }

        public AdminMateriaModel Obtener(int IdMateria)
        {
            AdminMateriaModel _materia = new AdminMateriaModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AdminMateriaObtener", conexion);
                cmd.Parameters.AddWithValue("IdAdminMateria", IdMateria);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _materia.IdAdminMateria = Convert.ToInt32(dr["IdAdminMateria"]);
                        _materia.NombreMat = dr["NombreMat"].ToString();


                    }
                }
            }
            return _materia;
        }

        public AdminMateriaModel Guardar(AdminMateriaModel model)//Procedimiento almacenado Guardar
        {

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AdminMateriaGuardar", conexion);
                    cmd.Parameters.AddWithValue("NombreMat", model.NombreMat);

                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            model.IdAdminMateria = Convert.ToInt32(dr["IdMateria"]);
                        }

                    }

                }

            }

            catch (Exception ex)
            {
                string error = ex.Message;

            }
            return model;
        }


        public bool Editar(AdminMateriaModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AdminMateriaEditar", conexion);
                    cmd.Parameters.AddWithValue("IdAdminMateria", model.IdAdminMateria);
                    cmd.Parameters.AddWithValue("NombreMat", model.NombreMat);
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


        public bool Eliminar(int IdElimMateria)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AdminMateriaEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdAdminMateria", IdElimMateria);
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

