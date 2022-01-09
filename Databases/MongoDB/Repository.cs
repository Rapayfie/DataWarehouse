using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataWarehouse.Databases.MongoDB
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly IMongoDatabase _db;
        private readonly string _database;
        private readonly string _table;
        private readonly MongoClient _client;
        
        public Repository(string table)
        {
            _table = table;
            _database = "DiseaseDB";
            _client = new MongoClient();
            _db = _client.GetDatabase(_database);
        }

        public void InsertMany(IEnumerable<TEntity> records)
        {
            var collection = _db.GetCollection<TEntity>(_table);
            collection.InsertMany(records);
        } 

        public void DeleteAll()
        {
            var collection = _db.GetCollection<TEntity>(_table);
            var filter = Builders<TEntity>.Filter.Empty;
            
            collection.DeleteMany(filter);
        }

        public void DropDatabase()
        {
            _client.DropDatabase(_database);
        }

        public ValueTask<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate)
        {
            var collection = _db.GetCollection<TEntity>(_table);

            return new ValueTask<IQueryable<TEntity>>(collection.AsQueryable().Where(predicate));
        }
    }
}