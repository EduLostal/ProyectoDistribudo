using CambioMoneda.Models;
using gestorFruteria.ConexionBase;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TuAplicacion.Services
{
    public class FrutaService
    {
        private readonly MongoDbContext _dbContext;

        public FrutaService(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //obtencion de todos los documentos
        public async Task<List<Fruta>> ObtenerTodasLasFrutasAsync()
        {
            return await _dbContext.Frutas.Find(_ => true).ToListAsync();
        }

        //Obtencion de documento por nombre de cada fruta
        public async Task<List<Fruta>> ObtenerFrutasPorNombreAsync(string nombreFruta)
        {
            return await _dbContext.Frutas.Find(f => f.NombreFruta == nombreFruta).ToListAsync();
        }

        //Creacion de nueva venta de fruta
        public async Task CrearFrutaAsync(Fruta nuevaFruta)
        {
            await _dbContext.Frutas.InsertOneAsync(nuevaFruta);
        }

        //Eliminacion venta
        public async Task EliminarFrutaAsync(ObjectId id)
        {
            await _dbContext.Frutas.DeleteOneAsync(f => f.Id == id);
        }

    }
}
