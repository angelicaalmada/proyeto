using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;

namespace Proyeto.datos
{
    public class EstudiosRealizadosDatos
    {
        public List<EstudiosRealizadosModel> Listar()
        {
            List<EstudiosRealizadosModel> Lista = new List<EstudiosRealizadosModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EstudioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new EstudiosRealizadosModel
                        {
                            IdEstudiosRealizados = Convert.ToInt32(dr["IdEstudio_R"]),
                            Matri_NoEmpl = Convert.ToInt32(dr["Matri_NoEmp"]),
                            NombreCurso = dr["NombreCurso"].ToString(),
                            Duracion = dr["Duracion"].ToString(),
                            Institucion = dr["InstitucionIm"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            UrlDocumento = dr["UrlDoc"].ToString(),
                            IdAutor1 = Convert.ToInt32(dr["IdAutor1"]),
                        });
                    }
                }
            }
            return Lista;
        }




        public EstudiosRealizadosModel Obtener(int IdEstudiosRealizados)
        {
            AutorDatos _datos = new AutorDatos();
            EstudiosRealizadosModel _estudios = new EstudiosRealizadosModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EstudioObtener", conexion);
                cmd.Parameters.AddWithValue("IdEstudio_R", IdEstudiosRealizados);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _estudios.IdEstudiosRealizados = Convert.ToInt32(dr["IdEstudio_R"]);
                        _estudios.Matri_NoEmpl = Convert.ToInt32(dr["Matri_NoEmp"]);
                        _estudios.NombreCurso = dr["NombreCurso"].ToString();
                        _estudios.Duracion = dr["Duracion"].ToString();
                        _estudios.Institucion = dr["Institucionim"].ToString();
                        _estudios.Descripcion = dr["Descripcion"].ToString();
                        _estudios.UrlDocumento = dr["UrlDoc"].ToString();
                        _estudios.IdAutor1 = Convert.ToInt32(dr["IdAutor1"]);
                        _estudios.Autor1 = _datos.Obtener(Convert.ToInt32(dr["IdAutor1"]));
                    }
                }
            }
            return _estudios;
        }



        public bool Guardar(EstudiosRealizadosModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EstudioGuardar", conexion);                   
                    cmd.Parameters.AddWithValue("Matri_NoEmp", model.Matri_NoEmpl);
                    cmd.Parameters.AddWithValue("NombreCurso", model.NombreCurso);
                    cmd.Parameters.AddWithValue("Duracion", model.Duracion);
                    cmd.Parameters.AddWithValue("InstitucionIm", model.Institucion);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
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


        public bool Editar(EstudiosRealizadosModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EstudioEditar", conexion);
                    cmd.Parameters.AddWithValue("@IdEstudio_R", model.IdEstudiosRealizados);
                    cmd.Parameters.AddWithValue("Matri_NoEmp", model.Matri_NoEmpl);
                    cmd.Parameters.AddWithValue("NombreCurso", model.NombreCurso);
                    cmd.Parameters.AddWithValue("Duracion", model.Duracion);
                    cmd.Parameters.AddWithValue("Institucionim", model.Institucion);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
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



        public bool Eliminar(int IdEstudiosRealizados)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EstudioEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdEstudio_R", IdEstudiosRealizados);
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
