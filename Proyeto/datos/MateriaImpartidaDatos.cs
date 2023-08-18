using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace Proyeto.datos
{
    public class MateriaImpartidaDatos
    {
        public List<MateriaImpartidaModel> Listar()
        {
            List<MateriaImpartidaModel> Lista = new List<MateriaImpartidaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_MateriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new MateriaImpartidaModel
                        {
                            IdMateria = Convert.ToInt32(dr["IdMateria"]),
                            Matricula = Convert.ToInt32(dr["Matricula"]),
                            CarreraModel = new CarreraAdminModel{
                                IdCaAdmin = Convert.ToInt32(dr["IdCaAdmin"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            },
                            //IdCarrera = Convert.ToInt32(dr["IdCaAdmin"].ToString()),
                            MateriaAdmin = new AdminMateriaModel {
                                IdAdminMateria=Convert.ToInt32(dr["IdAdminMateria"].ToString()),
                                NombreMat = dr["NombreMat"].ToString()
                            },
                            //IdMateriaAdmin = Convert.ToInt32(dr["IdAdminMateria"].ToString()),
                            Grupo = dr["Grupo"].ToString(),
                            FechaCuatri = dr["FechaCuatri"].ToString(),
                            UrlDocumento = dr["UrlDoc"].ToString(),
                            IdAutor1 = Convert.ToInt32(dr["IdAutor1"]),
                        });
                    }
                }
            }
            return Lista;
        }




        public MateriaImpartidaModel Obtener(int IdMateria)
        {
            MateriaImpartidaModel _materia = new MateriaImpartidaModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_MateriaObtener", conexion);
                cmd.Parameters.AddWithValue("IdMateria", IdMateria);
                cmd.CommandType = CommandType.StoredProcedure; 

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _materia.IdMateria = Convert.ToInt32(dr["IdMateria"]);
                        _materia.Matricula = Convert.ToInt32(dr["Matricula"]);
                        _materia.CarreraModel = new CarreraAdminModel
                        {
                            IdCaAdmin = Convert.ToInt32(dr["IdCaAdmin"].ToString()),
                            Nombre = dr["Nombre"].ToString()
                        };
                        //_materia.IdCarrera = Convert.ToInt32(dr["IdCaAdmin"].ToString());
                             _materia.MateriaAdmin = new AdminMateriaModel
                             {
                                 IdAdminMateria = Convert.ToInt32(dr["IdAdminMateria"].ToString()),
                                 NombreMat = dr["NombreMat"].ToString()
                             };
                        //_materia.IdMateriaAdmin = Convert.ToInt32(dr["IdAdminMateria"].ToString());
                        _materia.Grupo = dr["Grupo"].ToString();
                        _materia.FechaCuatri = dr["FechaCuatri"].ToString();
                        _materia.UrlDocumento = dr["UrlDoc"].ToString();
                        _materia.IdAutor1 = Convert.ToInt32(dr["IdAutor1"]);
                    }
                }
            }
            return _materia;
        }



        public bool Guardar(MateriaImpartidaModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_MateriaGuardar", conexion);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("IdCaAdmin", model.CarreraModel.IdCaAdmin);
                    cmd.Parameters.AddWithValue("IdAdminMateria", model.MateriaAdmin.IdAdminMateria);
                    cmd.Parameters.AddWithValue("Grupo", model.Grupo);
                    cmd.Parameters.AddWithValue("FechaCuatri", model.FechaCuatri);
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


        public bool Editar(MateriaImpartidaModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_MateriaEditar", conexion);
                    cmd.Parameters.AddWithValue("IdMateria", model.IdMateria);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("IdCaAdmin", model.CarreraModel.IdCaAdmin);
                    cmd.Parameters.AddWithValue("IdAdminMateria", model.MateriaAdmin.IdAdminMateria);
                    cmd.Parameters.AddWithValue("Grupo", model.Grupo);
                    cmd.Parameters.AddWithValue("FechaCuatri", model.FechaCuatri);
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



        public bool Eliminar(int IdMateria)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_MateriaEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdMateria", IdMateria);
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
