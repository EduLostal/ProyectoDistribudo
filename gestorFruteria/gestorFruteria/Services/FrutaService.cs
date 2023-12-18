using gestorFruteria.Models;
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
        public async Task ModificacionAsync(ObjectId id,Fruta cambiosFruta)
        {
            var update = Builders<Fruta>.Update;
            var updateDef = new List<UpdateDefinition<Fruta>>();

            if (!string.IsNullOrEmpty(cambiosFruta.NombreFruta))
                updateDef.Add(update.Set(f => f.NombreFruta, cambiosFruta.NombreFruta));

            if (cambiosFruta.Cantidad > 0)
                updateDef.Add(update.Set(f => f.Cantidad, cambiosFruta.Cantidad));

            if (cambiosFruta.PrecioPorUnidad > 0)
                updateDef.Add(update.Set(f => f.PrecioPorUnidad, cambiosFruta.PrecioPorUnidad));
            if(!string.IsNullOrEmpty(cambiosFruta.Proveedor.Nombre))
                updateDef.Add(update.Set(f => f.Proveedor.Nombre, cambiosFruta.Proveedor.Nombre));
            if (!string.IsNullOrEmpty(cambiosFruta.Proveedor.Contacto))
                updateDef.Add(update.Set(f => f.Proveedor.Contacto, cambiosFruta.Proveedor.Contacto));
            if (!string.IsNullOrEmpty(cambiosFruta.Proveedor.Telefono))
                updateDef.Add(update.Set(f => f.Proveedor.Telefono, cambiosFruta.Proveedor.Telefono));
            if (!string.IsNullOrEmpty(cambiosFruta.Venta.Cliente))
                updateDef.Add(update.Set(f => f.Venta.Cliente, cambiosFruta.Venta.Cliente));
            if (cambiosFruta.Venta.CantidadVendida >0)
                updateDef.Add(update.Set(f => f.Venta.CantidadVendida, cambiosFruta.Venta.CantidadVendida));
            if (cambiosFruta.Venta.PrecioVenta > 0)
                updateDef.Add(update.Set(f => f.Venta.PrecioVenta, cambiosFruta.Venta.PrecioVenta));
            if (cambiosFruta.Venta.FechaVenta > DateTime.MinValue)
                updateDef.Add(update.Set(f => f.Venta.FechaVenta, cambiosFruta.Venta.FechaVenta));
            

            if (updateDef.Count > 0)
            {
                var combinedUpdate = update.Combine(updateDef);
                await _dbContext.Frutas.UpdateOneAsync(f => f.Id == id, combinedUpdate);
            }


        

        }

        //Eliminacion venta
        public async Task EliminarFrutaAsync(ObjectId id)
        {
            await _dbContext.Frutas.DeleteOneAsync(f => f.Id == id);
        }

    }
}
