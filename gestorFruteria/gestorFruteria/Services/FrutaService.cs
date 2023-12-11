using CambioMoneda.Models;
using gestorFruteria.ConexionBase;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            var frutaExistente = _dbContext.Frutas
              .Find(f => f.NombreFruta == NombreFruta &&
                         f.Proveedor.Nombre == NombreProovedor &&
                         f.Venta.Cliente == NombreCliente);

          
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
        public async Task ModificacionAsync(ObjectId id,Fruta actualizafruta)
        {
            await _dbContext.Frutas.DeleteOneAsync(f => f.Id == id);
            _ = CrearFrutaAsync(actualizafruta);
           
        }

        //Eliminacion venta
        public async Task EliminarFrutaAsync(ObjectId id)
        {
            await _dbContext.Frutas.DeleteOneAsync(f => f.Id == id);
        }

    }
}
