using gestorFruteria.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;


namespace gestorFruteria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrutaController : ControllerBase
    {
        private readonly Enlace enlace;

        public FrutaController(Enlace frutaManager)
        {
            enlace = frutaManager;
        }

        // Obtener todas las frutas
        [HttpGet]
        public async Task<ActionResult<List<Fruta>>> GetAll()
        {
            return await enlace.GetAllAsync();
        }

        // Obtener una fruta específica por ID
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Fruta>> Get(string id)
        {
            var fruta = await enlace.GetAsync(new ObjectId(id));
            if (fruta == null)
            {
                return NotFound();
            }

            return fruta;
        }

        // Añadir una nueva fruta
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Fruta nuevaFruta)
        {
            await enlace.AddAsync(nuevaFruta);
            return CreatedAtAction(nameof(Get), new { id = nuevaFruta.Id.ToString() }, nuevaFruta);
        }

        // Actualizar una fruta existente
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Fruta frutaActualizada)
        {
            var fruta = await enlace.GetAsync(new ObjectId(id));
            if (fruta == null)
            {
                return NotFound();
            }

            await enlace.UpdateAsync(new ObjectId(id), frutaActualizada);
            return NoContent();
        }

        // Eliminar una fruta por ID
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var fruta = await enlace.GetAsync(new ObjectId(id));
            if (fruta == null)
            {
                return NotFound();
            }

            await enlace.DeleteAsync(new ObjectId(id));
            return NoContent();
        }
    }
}
