using System.Data.SqlClient;
using System.Data;
using TiendaAPI.Conexion;
using TiendaAPI.Modelo;
using System.Runtime.CompilerServices;

namespace TiendaAPI.Datos
{
    public class DatosProductos
    {
        ConexionBD conexionBD = new ConexionBD();
        public async Task<List<ModeloProductos>> MostrarProductos()
        {
            var lista = new List<ModeloProductos>();

            using (var connSql = new SqlConnection(conexionBD.ConnectionString()))
            {
                using (var cmd = new SqlCommand("mostrarProductos", connSql))
                {
                    await connSql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var modeloProductos = new ModeloProductos();
                            modeloProductos.Id = (int)item["id"];
                            modeloProductos.Descripcion = (string)item["descripcion"];
                            modeloProductos.Precio = (decimal)item["precio"];

                            lista.Add(modeloProductos);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarProductos(ModeloProductos parametros)
        {
            using (var connSql = new SqlConnection(conexionBD.ConnectionString()))
            {
                using (var cmd = new SqlCommand("insertarProductos", connSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", parametros.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.Precio);
                    await connSql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditarProductos(ModeloProductos parametros)
        {
            using (var connSql = new SqlConnection(conexionBD.ConnectionString()))
            {
                using (var cmd = new SqlCommand("editarProductos", connSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.Id);
                    cmd.Parameters.AddWithValue("@precio", parametros.Precio);
                    await connSql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarProductos(ModeloProductos parametros)
        {
            using (var connSql = new SqlConnection(conexionBD.ConnectionString()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", connSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.Id);
                    await connSql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
