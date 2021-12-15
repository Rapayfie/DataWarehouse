using Microsoft.EntityFrameworkCore;  
using System.Collections.Generic;  
using System.Linq;

namespace DataWarehouse.Databases.MSSQL
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly DiseasesContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository()
        {
            this._context = new DiseasesContext();
            this._dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void InsertMany(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }
        
        public void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void DeleteAll()
        {
            var rows = _dbSet.Select(row => row);
            _dbSet.RemoveRange(rows);
        }
        
        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}