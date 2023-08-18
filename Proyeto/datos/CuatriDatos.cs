using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;
namespace Proyeto.datos
{
    public class CuatriDatos
    {
            public List<CuatriModel> Listar()
            {
                List<CuatriModel> Lista = new List<CuatriModel>();
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CuatriListar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new CuatriModel
                            {
                                IdCuatrimestre = Convert.ToInt32(dr["IdCuatrimestre"]),
                                NombreCuatri = dr["NombreCuatri"].ToString(),
                                UrlDocumento = dr["UrlDoc"].ToString(),
                                IdAutor1 = Convert.ToInt32(dr["IdAutor1"]),

                            });
                        }
                    }
                }
                return Lista;
            }


            public CuatriModel Obtener(int IdCuatrimestre)
            {
                CuatriModel _cuatri = new CuatriModel();
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CuatriObtener", conexion);
                    cmd.Parameters.AddWithValue("IdCuatri", IdCuatrimestre);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            _cuatri.IdCuatrimestre = Convert.ToInt32(dr["IdCuatrimestre"]);
                            _cuatri.NombreCuatri = dr["NombreCuatri"].ToString();
                        _cuatri.UrlDocumento = dr["UrlDoc"].ToString();
                        _cuatri.IdAutor1 = Convert.ToInt32(dr["IdAutor1"]);
                    }
                    }
                }
                return _cuatri;
            }



            public bool Guardar(CuatriModel model)//Procedimiento almacenado Guardar
            {
                bool respuesta;
                try
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSql()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("sp_CuatriGuardar", conexion);
                        cmd.Parameters.AddWithValue("NombreCuatri", model.NombreCuatri);
                        cmd.Parameters.AddWithValue("UrlDoc", model.UrlDocumento);
                        cmd.Parameters.AddWithValue("IdAutor1", model.IdAutor1);
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


            public bool Editar(CuatriModel model) //Procedimiento almacenado Editar
            {
                bool respuesta;
                try
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSql()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("sp_CuatriEditar", conexion);
                        cmd.Parameters.AddWithValue("IdCuatri", model.IdCuatrimestre);
                        cmd.Parameters.AddWithValue("NombreCuatri", model.NombreCuatri);
                        cmd.Parameters.AddWithValue("UrlDoc", model.UrlDocumento);
                        cmd.Parameters.AddWithValue("IdAutor1", model.IdAutor1);
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



            public bool Eliminar(int IdCuatrimestre)//Procedimiento almacenado Eliminar
            {
                bool respuesta;
                try
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSql()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("sp_CuatriEliminar", conexion);
                        cmd.Parameters.AddWithValue("IdCuatri", IdCuatrimestre);
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
