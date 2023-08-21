using Proyeto.Models;
using System.Data.SqlClient;
using System.Data;

namespace Proyeto.datos
{

    public class HistorialDocDatos
    {

        public List<HistorialDocModel> Listar()
        {
            //CREAR UNA LISTA VACIA
            var oLista = new List<HistorialDocModel>();
            //CREAR UNA INSTANCIA DE LA CLASE CONEXION
            var cn = new Conexion();
            //UTILIZAR USING PARA ESTABLECER LA CADENDA DE CONEXION
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                //COMANDO A EJECUTAR
                SqlCommand cmd = new SqlCommand("sp_ListarHistorialDoc", conexion);
                //TIPO DE COMANDO
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //SE LEE Y SE MANDA A la base d edatos
                        oLista.Add(new HistorialDocModel
                        {
                            IdAutor = Convert.ToInt32(dr["IdAutor"]),
                            TipoDoc = dr["TipoDoc"].ToString(),
                            IdDoc = Convert.ToInt32(dr["IdDoc"]),
                            Fecha = DateTime.Parse(dr["Fecha"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            NombreDocMat = dr["NombreDocMat"].ToString()

                        }); ;
                    }
                }
            }
            return oLista;
        }




    }

}
