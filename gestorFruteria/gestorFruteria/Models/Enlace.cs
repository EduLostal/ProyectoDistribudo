using MongoDB.Driver;
using gestorFruteria.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace gestorFruteria.Models
{
    public class Enlace
    {
        private readonly IMongoCollection<Fruta> _frutas;

        public Enlace(IMongoClient client, string databaseName, string collectionName)
        {
            var database = client.GetDatabase(databaseName);
            _frutas = database.GetCollection<Fruta>(collectionName);
        }

        // Obtener todas las frutas junto con su proveedor y venta
        public async Task<List<Fruta>> GetAllAsync()
        {
            return await _frutas.Find(_ => true).ToListAsync();
        }

        // Obtener una fruta específica por ObjectId
        public async Task<Fruta> GetAsync(ObjectId id)
        {
            return await _frutas.Find<Fruta>(fruta => fruta.Id == id).FirstOrDefaultAsync();
        }

        // Añadir una nueva fruta junto con su proveedor y venta
        public async Task AddAsync(Fruta nuevaFruta)
        {
            await _frutas.InsertOneAsync(nuevaFruta);
        }

        // Actualizar una fruta existente junto con su proveedor y venta
        public async Task UpdateAsync(ObjectId id, Fruta frutaActualizada)
        {
            await _frutas.ReplaceOneAsync(fruta => fruta.Id == id, frutaActualizada);
        }

        // Eliminar una fruta por ObjectId
        public async Task DeleteAsync(ObjectId id)
        {
            await _frutas.DeleteOneAsync(fruta => fruta.Id == id);
        }
    }
}
