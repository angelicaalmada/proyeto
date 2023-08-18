using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;

namespace Proyeto.datos
{
    public class DocumentoDatos
    {
        public List<DocumentoModel>Listar()
        {
            List<DocumentoModel> Lista = new List<DocumentoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_DocumentoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new DocumentoModel
                        {
                            IdDocumento = Convert.ToInt32(dr["IdDocumento"]),
                            Estatus = dr["Estatus"].ToString(),
                            CoAutor = dr["CoAutor"].ToString(),
                            IdCategoria1 = Convert.ToInt32(dr["IdCategoria1"]),
                            Urldocumento = dr["Urldocumento"].ToString(),
                        });
                    }
                }
            }
            return Lista;
        }




        public DocumentoModel Obtener(int IdDocumento)
        {
            DocumentoModel _documento = new DocumentoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_DocumentoObtener", conexion);
                cmd.Parameters.AddWithValue("IdDocumento", IdDocumento);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _documento.IdDocumento = Convert.ToInt32(dr["IdDocumento"]);
                        _documento.Estatus = dr["Estatus"].ToString();
                        _documento.CoAutor = dr["CoAutor"].ToString();
                        _documento.IdCategoria1 = Convert.ToInt32(dr["IdCategoria1"]);
                        _documento.Urldocumento = dr["Urldocumento"].ToString();

                    }
                }
            }
            return _documento;
        }


        public bool Guardar(DocumentoModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_DocumentoGuardar", conexion);
                    cmd.Parameters.AddWithValue("Estatus", model.Estatus);
                    cmd.Parameters.AddWithValue("CoAutor", model.CoAutor);
                    cmd.Parameters.AddWithValue("IdCategoria1", model.IdCategoria1);
                    cmd.Parameters.AddWithValue("Urldocumento", model.Urldocumento);
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



        public bool Editar(DocumentoModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_DocumentoEditar", conexion);
                    cmd.Parameters.AddWithValue("IdDocumento", model.IdDocumento);
                    cmd.Parameters.AddWithValue("Estatus", model.Estatus);
                    cmd.Parameters.AddWithValue("CoAutor", model.CoAutor);
                    cmd.Parameters.AddWithValue("IdCategoria1", model.IdCategoria1);
                    cmd.Parameters.AddWithValue("Urldocumento", model.Urldocumento);
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



        public bool Eliminar(int IdDocumento)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_DocumentoEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdDocumento", IdDocumento);
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
