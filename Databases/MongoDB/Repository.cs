using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using MongoDB.Driver;

namespace DataWarehouse.Databases.MongoDB
{
    public class Repository<TDocument> where TDocument : class
    {
        #region Fields
        private readonly IMongoCollection<TDocument> _collection;
        #endregion

        #region Constructor
        public Repository(string table)
        {
            var database = "DiseaseDB";
            var client = new MongoClient();
            var db = client.GetDatabase(database);
            _collection = db.GetCollection<TDocument>(table);
        }
        #endregion

        #region Implementation
        public void InsertMany(IEnumerable<TDocument> records)
        {
            _collection.InsertMany(records);
        } 

        public void DeleteAll()
        {
            var filter = Builders<TDocument>.Filter.Empty;
            _collection.DeleteMany(filter);
        }

        public ValueTask<IQueryable<TDocument>> Query(
            Expression<Func<TDocument, bool>> filter = null,
            int skip = 0,
            int take = int.MaxValue,
            Func<IQueryable<TDocument>, IOrderedQueryable<TDocument>> orderBy = null,
            Func<IQueryable<TDocument>, IIncludableQueryable<TDocument, object>> include = null)
        {
            var resetSet = filter != null ? 
                _collection.AsQueryable().Where(filter): _collection.AsQueryable();

            if (include != null)
            {
                resetSet = include(resetSet);
            }
            if (orderBy != null)
            {
                resetSet = orderBy(resetSet).AsQueryable();
            }
            resetSet = skip == 0 ? resetSet.Take(take) : resetSet.Skip(skip).Take(take).AsQueryable();
            return new ValueTask<IQueryable<TDocument>>(resetSet);
        }
        #endregion
    }
}