using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;
namespace Proyeto.datos
{
    public class AutorDatos
    {
        public List<AutorModel> Listar()
        {
            List<AutorModel> Lista = new List<AutorModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AutorListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new AutorModel
                        {
                            IdAutor = Convert.ToInt32(dr["IdAutor"]),
                            Nombre = dr["Nombre"].ToString(),
                            ApePaterno = dr["ApePaterno"].ToString(),
                            ApeMaterno = dr["ApeMaterno"].ToString(),
                            Matricula = dr["Matricula"] != DBNull.Value ? Convert.ToInt32(dr["Matricula"]) : 0,
                           NumEmpleado = dr["NumEmpleado"] != DBNull.Value ? Convert.ToInt32(dr["NumEmpleado"]) : 0,
                            IdTipoCuenta = Convert.ToInt32(dr["IdTipoCuenta"]),
                            NumTelefono = dr["NumTelefono"].ToString(),
                            FechaNaci = Convert.ToDateTime(dr["FechaNaci"]),
                            CuerpoAcademico = dr["CuerpoAcademico"].ToString(),
                            AreaEstudios = dr["AreaEstudios"].ToString(),
                            IdNivelEstudios1 = Convert.ToInt32(dr["IdNivelEstudios1"])

                        });
                    }
                }
            }
            return Lista;
        }

        public AutorModel Obtener(int IdAutor)
        {
            AutorModel _autor = new AutorModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AutorObtener", conexion);
                cmd.Parameters.AddWithValue("IdAutor", IdAutor);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _autor.IdAutor = Convert.ToInt32(dr["IdAutor"]);
                        _autor.Nombre = dr["Nombre"].ToString();
                        _autor.ApePaterno = dr["ApePaterno"].ToString();
                        _autor.ApeMaterno = dr["ApeMaterno"].ToString();
                        _autor.Matricula = dr["Matricula"] != DBNull.Value ? Convert.ToInt32(dr["Matricula"]):0;
                        _autor.NumEmpleado = dr["NumEmpleado"]!=DBNull.Value?Convert.ToInt32(dr["NumEmpleado"]):0;
                        _autor.IdTipoCuenta = Convert.ToInt32(dr["IdTipoCuenta"]);
                        _autor.NumTelefono = dr["NumTelefono"].ToString();
                        _autor.FechaNaci = Convert.ToDateTime(dr["FechaNaci"]);
                        _autor.CuerpoAcademico = dr["CuerpoAcademico"].ToString();
                        _autor.AreaEstudios = dr["AreaEstudios"].ToString();
                        _autor.IdNivelEstudios1 = Convert.ToInt32(dr["IdNivelEstudios1"]);
                    
                    }
                }
            }
            return _autor;
        }

        public AutorModel Guardar(AutorModel model)//Procedimiento almacenado Guardar
        {
            
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AutorGuardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("ApePaterno", model.ApePaterno);
                    cmd.Parameters.AddWithValue("ApeMaterno", model.ApeMaterno);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("NumEmpleado", model.NumEmpleado);
                    cmd.Parameters.AddWithValue("IdTipoCuenta", model.IdTipoCuenta);
                    cmd.Parameters.AddWithValue("NumTelefono", model.NumTelefono);
                    cmd.Parameters.AddWithValue("FechaNaci", model.FechaNaci);
                    cmd.Parameters.AddWithValue("CuerpoAcademico", model.CuerpoAcademico);
                    cmd.Parameters.AddWithValue("AreaEstudios", model.AreaEstudios);
                    cmd.Parameters.AddWithValue("IdNivelEstudios1", model.IdNivelEstudios1);

                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            model.IdAutor = Convert.ToInt32(dr["IdAutor"]);
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


        public bool Editar(AutorModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AutorEditar", conexion);
                    cmd.Parameters.AddWithValue("IdAutor", model.IdAutor);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("ApePaterno", model.ApePaterno);
                    cmd.Parameters.AddWithValue("ApeMaterno", model.ApeMaterno);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("NumEmpleado", model.NumEmpleado);
                    cmd.Parameters.AddWithValue("IdTipoCuenta", model.IdTipoCuenta);
                    cmd.Parameters.AddWithValue("NumTelefono", model.NumTelefono);
                    cmd.Parameters.AddWithValue("FechaNaci", model.FechaNaci);
                    cmd.Parameters.AddWithValue("CuerpoAcademico", model.CuerpoAcademico);
                    cmd.Parameters.AddWithValue("AreaEstudios", model.AreaEstudios);
                    cmd.Parameters.AddWithValue("IdNivelEstudios1", model.IdNivelEstudios1);
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


        public bool Eliminar(int idAutor)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AutorEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdAutor", idAutor);
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
