using MongoDB.Driver;
using gestorFruteria.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using gestorFruteria.ConexionBase;

namespace gestorFruteria.Models
{
    public  class Enlace
    {
        private  readonly IMongoCollection<Fruta> _frutas;

        public  Enlace()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("pruebaProyecto");
            _frutas = database.GetCollection<Fruta>("PRUEBAS");
        }

        // Obtener todas las frutas junto con su proveedor y venta
        public  async List<Fruta> GetAllAsync()
        {
            List<Fruta> list = new List<Fruta>();
            
            var filter = Builders<Fruta>.Filter.Empty;
            await _frutas.Find(filter).ToListAsync();
            list.Add(filter);

        }

        // Obtener una fruta específica por ObjectId
        public  async Task<Fruta> GetAsync(ObjectId id)
        {
            return await _frutas.Find<Fruta>(fruta => fruta.Id == id).FirstOrDefaultAsync();
        }

        // Añadir una nueva fruta junto con su proveedor y venta
        public  async Task AddAsync(Fruta nuevaFruta)
        {
            await _frutas.InsertOneAsync(nuevaFruta);
        }

        // Actualizar una fruta existente junto con su proveedor y venta
        public  async Task UpdateAsync(ObjectId id, Fruta frutaActualizada)
        {
            await _frutas.ReplaceOneAsync(fruta => fruta.Id == id, frutaActualizada);
        }

        // Eliminar una fruta por ObjectId
        public  async Task DeleteAsync(ObjectId id)
        {
            await _frutas.DeleteOneAsync(fruta => fruta.Id == id);
        }
    }
}
