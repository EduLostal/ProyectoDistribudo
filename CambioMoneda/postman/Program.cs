using MongoDB.Bson;
using MongoDB.Driver;
using CambioMoneda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postman
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("pruebaProyecto");
            var collection = database.GetCollection<Fruta>("PRUEBAS");

            var filter = Builders<Fruta>.Filter.Eq("_id", new ObjectId("656ce715327d9d02a171a6ec"));
            var update = Builders<Fruta>.Update.Set(f => f.NombreFruta, "Sandia");
            var post = Builders<Fruta>.       Update.Set(f => f.NombreFruta, "Sandia");

            collection.UpdateOne(filter, update);
            var result = collection.UpdateOne(filter, update);
            Console.WriteLine($"Matched count: {result.MatchedCount}, Modified count: {result.ModifiedCount}");

        }
    }
}
