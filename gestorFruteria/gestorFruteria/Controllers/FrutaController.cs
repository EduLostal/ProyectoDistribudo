using CambioMoneda.Models;
using gestorFruteria.ConexionBase;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Web.Http;
using TuAplicacion.Services;

namespace gestorFruteria.Controllers
{
    public class FrutaController : ApiController
    {
        private readonly FrutaService _frutaService;

        public FrutaController()
        {
            var dbContext = new MongoDbContext(); 
            _frutaService = new FrutaService(dbContext);
        }

        public async Task<IHttpActionResult> GetAsync()
        {
            var frutas = await _frutaService.ObtenerTodasLasFrutasAsync();
            return Ok(frutas);
        }

        [HttpGet]
        [Route("api/fruta/{nombreFruta}")]
        public async Task<IHttpActionResult> GetPorNombreAsync(string nombreFruta)
        {
            var fruta = await _frutaService.ObtenerFrutasPorNombreAsync(nombreFruta);
            if (fruta != null)
            {
                return Ok(fruta);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/frutas")]
        public async Task<IHttpActionResult> CrearFruta(Fruta nuevaFruta)
        {
            if (nuevaFruta == null)
            {
                return BadRequest("Datos de fruta invalidos...");
            }

            await _frutaService.CrearFrutaAsync(nuevaFruta);

            return Ok("Fruta creada con exito...");
        }

        [HttpDelete]
        [Route("api/frutas/{id}")]
        public async Task<IHttpActionResult> EliminarFruta(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("ID inválido.");
            }

            await _frutaService.EliminarFrutaAsync(objectId);

            return Ok("Fruta eliminada con éxito.");
        }

    }
}


