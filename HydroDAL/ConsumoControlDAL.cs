using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HydroDAL
{
    public class ConsumoControlDAL
    {
        private IMongoDatabase db;

        public void insertRecord<T>(T record)
        {
            var client = new MongoClient();
            db = client.GetDatabase("ControleAgua");
            var table = "ControleAguaPorUsuario";
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> ListarTodosDados<T>()
        {
            var client = new MongoClient();
            db = client.GetDatabase("ControleAgua");
            var table = "ControleAguaPorUsuario";
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public List<T> BuscarPorCodCliente<T>(int codCliente)
        {
            var client = new MongoClient();
            db = client.GetDatabase("ControleAgua");
            var table = "ControleAguaPorUsuario";
            var collection = db.GetCollection<T>(table);
            var filters = Builders<T>.Filter.Eq("Cliente.CodCliente", codCliente);
            return collection.Find(filters).ToList();
        }
    }
}
