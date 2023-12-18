using gestorFruteria.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestorFruteria.ConexionBase
{
    public class MongoDbContext
    {
        public IMongoCollection<Fruta> Frutas { get; set; }

        //Cambiar datos si tienes otro puerto u otra base
        public MongoDbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("pruebaProyecto");
            Frutas = database.GetCollection<Fruta>("PRUEBAS");
        }
    }
}