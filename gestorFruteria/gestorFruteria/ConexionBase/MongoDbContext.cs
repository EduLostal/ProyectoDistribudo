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

        public MongoDbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("pruebaProyecto");
            var collection = database.GetCollection<Fruta>("PRUEBAS");
        }

    }
}