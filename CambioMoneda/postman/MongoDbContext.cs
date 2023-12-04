using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace postman
{
    

    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("pruebaProyecto");
        }

        public IMongoCollection<BsonDocument> GetCollection()
        {
            return _database.GetCollection<BsonDocument>("PRUEBAS");
        }


        
    }

}
