using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;
using System.Data.SqlClient;

namespace Proyeto.Controllers
{
    public class HomeAleController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeAleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUsuarios()
        {
            return View("Index", GetUsuariosFromDB());
        }

        private List<UsuarioModel> GetUsuariosFromDB()
        {
            var cn = new Conexion();
            List<UsuarioModel> usuarios = new List<UsuarioModel>();
            //string connectionString = _configuration.GetConnectionString("MiConexion");
            using (SqlConnection connection = new SqlConnection(cn.getCadenaSql()))
            {
                string query = "SELECT * FROM Usuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioModel usuario = new UsuarioModel
                            {
                                NombreUsuario = reader["NombreUsuario"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Contrasena = reader["Contrasena"].ToString(),
                                IdAutor1 = Convert.ToInt32(reader["IdAutor1"])
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }
    }
}
