using CambioMoneda.Models;
using gestorFruteria.ConexionBase;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;

namespace TuAplicacion.Services
{
    public class FrutaService
    {
        private readonly MongoDbContext _dbContext;

        public FrutaService(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        //Obtencion de nombre fruta
        public bool ComprobacionBase(string NombreFruta, string NombreProovedor, string NombreCliente)
        {

            var filtro = Builders<Fruta>.Filter.Eq(f => f.NombreFruta, NombreFruta) &
                  Builders<Fruta>.Filter.Eq(f => f.Proveedor.Nombre, NombreProovedor) &
                  Builders<Fruta>.Filter.Eq(f => f.Venta.Cliente, NombreCliente);

            var frutaExistente = _dbContext.Frutas.Find(filtro).FirstOrDefault();

            return frutaExistente != null;

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
        //Modificacion fruta
        public async Task ModificacionAsync(ObjectId id,Fruta actualizaFruta)
        {                       
            actualizaFruta.Id = id;

           
            await _dbContext.Frutas.ReplaceOneAsync(f => f.Id == id, actualizaFruta);

        }

        //Eliminacion venta
        public async Task EliminarFrutaAsync(ObjectId id)
        {
            await _dbContext.Frutas.DeleteOneAsync(f => f.Id == id);
        }

    }
}
