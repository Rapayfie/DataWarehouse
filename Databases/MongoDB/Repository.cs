using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataWarehouse.Databases.MongoDB
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly IMongoDatabase _db;
        private readonly string _database;
        private readonly string _table;
        public Repository(string table)
        {
            _table = table;
            _database = "DiseaseDB";
            var client = new MongoClient();
            _db = client.GetDatabase(_database);
        }

        public void Insert(TEntity record)
        {
            var collection = _db.GetCollection<TEntity>(_table);
            collection.InsertOne(record);
        }

        public void InsertMany(IEnumerable<TEntity> records)
        {
            var collection = _db.GetCollection<TEntity>(_table);
            collection.InsertMany(records);
        } 
        
        public IEnumerable<TEntity> LoadRecords()
        {
            var collection = _db.GetCollection<TEntity>(_table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public TEntity LoadById(Guid id)
        {
            var collection = _db.GetCollection<TEntity>(_table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }

        public void Upsert(Guid id, TEntity record)
        {
            var collection = _db.GetCollection<TEntity>(_table);

            var result = collection.ReplaceOne(
                new BsonDocument("_id", id),
                record,
                new ReplaceOptions {IsUpsert = true}
            );
        }

        public void Delete(Guid id)
        {
            var collection = _db.GetCollection<TEntity>(_table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);

            collection.DeleteOne(filter);
        }

        public void DeleteAll()
        {
            var collection = _db.GetCollection<TEntity>(_table);
            var filter = Builders<TEntity>.Filter.Empty;
            
            collection.DeleteMany(filter);
        }
    }
}