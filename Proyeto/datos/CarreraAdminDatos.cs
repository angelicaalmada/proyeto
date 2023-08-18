using Microsoft.AspNetCore.Mvc;
using Proyeto.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyeto.datos
{
    public class CarreraAdminDatos
    {

        //LISTAR
        public List<CarreraAdminModel> Listar()
        {
            //CREAR UNA LISTA VACIA
            var oLista = new List<CarreraAdminModel>();
            //CREAR UNA INSTANCIA DE LA CLASE CONEXION
            var cn = new Conexion();
            //UTILIZAR USING PARA ESTABLECER LA CADENA DE CONEXION
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                //ABRIR LA CONEXION
                conexion.Open();
                //COMANDO A EJECUTAR
                SqlCommand cmd = new SqlCommand("sp_CaAdminListar", conexion);
                //DECIR EL TIPO DE COMANDO
                cmd.CommandType = CommandType.StoredProcedure;
                //LEER EL RESULTADO DE LA EJECUCION DEL PROCEDIMIENTO ALMACENADO
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //UNA VEZ QUE SE ESTEN LEYENDO SE GUARDA TAMBIEN
                        //EN LA LISTA
                        oLista.Add(new CarreraAdminModel()
                        {
                            IdCaAdmin = Convert.ToInt32(dr["IdCaAdmin"]),
                            Nombre = dr["Nombre"].ToString()
                           

                        });
                    }
                }
            }
            return oLista;
        }

        //OBTENER
        public CarreraAdminModel ObtenerAdminCarrera(int IdCaAdmin)
        {
            //CREAR UN OBJETO VACIO
            var oCaAdmin = new CarreraAdminModel();
            var cn = new Conexion();
            //UTILIZAR USING PARA ESTABLECER LA CADENA DE CONEXION
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_CaAdminObtener", conexion);
                //ENVIAR UN PARAMETRO AL  SP
                cmd.Parameters.AddWithValue("IdCaAdmin", IdCaAdmin);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //ASIGNAR VALORES AL OBJETO oCaAdmin
                        oCaAdmin.IdCaAdmin = Convert.ToInt32(dr["IdCaAdmin"]);                       
                        oCaAdmin.Nombre = dr["Nombre"].ToString();
                    }
                }
            }
            return oCaAdmin;

        }

        //GUARDAR
        public bool GuardarAdminCarrera(CarreraAdminModel model)
        {
            //CREAR VARIABLE BOOL
            bool respuesta;
            try
            {
                var cn = new Conexion();
                //ESTABLECER UNA CADENA DE CONEXION
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CaAdminGuardar", conexion);
                    //ENVIANDO UN PARAMETRO AL PROCEDIMIENTO ALMACENADO
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    //EJECUTAR EL SP 
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //EDITAR
        public bool EditarAdminCarrera(CarreraAdminModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                //UTILIZAR USING PARA ESTABLECER LA CADENA DE CONEXION
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CaAdminEditar", conexion);
                    //ENVIANDO UN PARAMETRO AL SP
                    cmd.Parameters.AddWithValue("IdCaAdmin", model.IdCaAdmin);                  
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //ELIMINAR
        public bool EliminarAdminCarrera(int IdCaAdmin)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CaAdminEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdCaAdmin", IdCaAdmin);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }
}
