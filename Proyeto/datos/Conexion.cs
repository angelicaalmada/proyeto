namespace Proyeto.datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            cadenaSql = builder.GetSection("ConnectionString:cadenaSql").Value;
        }
        public string getCadenaSql()
        { return cadenaSql; }
    }
}
