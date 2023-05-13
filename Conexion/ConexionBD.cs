namespace TiendaAPI.Conexion
{
    public class ConexionBD
    {
        private string connString = string.Empty;

        public ConexionBD()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            connString = constructor.GetSection("ConnectionStrings:connectionString").Value;

        }

        public string ConnectionString()
        {
            return connString;
        }
    }
}
