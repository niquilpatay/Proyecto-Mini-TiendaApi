using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Datos;
using TiendaAPI.Modelo;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ModeloProductos>>> Get()
        {
            var funcion = new DatosProductos();
            var lista = await funcion.MostrarProductos();

            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] ModeloProductos parametros)
        {
            var funcion = new DatosProductos();
            await funcion.InsertarProductos(parametros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] ModeloProductos parametros)
        {
            var funcion = new DatosProductos();
            parametros.Id = id;
            await funcion.EditarProductos(parametros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var funcion = new DatosProductos();
            var parametros = new ModeloProductos();
            parametros.Id = id;
            await funcion.EliminarProductos(parametros);
            return NoContent();
        }
    }
}
