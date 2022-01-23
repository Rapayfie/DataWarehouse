using System;
using Microsoft.EntityFrameworkCore;  
using System.Collections.Generic;  
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace DataWarehouse.Databases.MSSQL
{
    public class Repository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly DiseasesContext _context;
        private readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Constructor
        public Repository()
        {
            _context = new DiseasesContext();
            _dbSet = _context.Set<TEntity>();
        }
        #endregion

        #region Implementation
        public void InsertMany(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }
        
        public void DeleteAll()
        {
            var rows = _dbSet.Select(row => row);
            _dbSet.RemoveRange(rows);
            _context.SaveChanges();
        }
        
        public IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> filter = null,
            int skip = 0,
            int take = int.MaxValue,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var resetSet = filter != null ? 
                _dbSet.AsNoTracking().Where(filter).AsQueryable() : _dbSet.AsNoTracking().AsQueryable();

            if (include != null)
            {
                resetSet = include(resetSet);
            }
            if (orderBy != null)
            {
                resetSet = orderBy(resetSet).AsQueryable();
            }
            resetSet = skip == 0 ? resetSet.Take(take) : resetSet.Skip(skip).Take(take);
            return resetSet;
        }
        #endregion
    }
}