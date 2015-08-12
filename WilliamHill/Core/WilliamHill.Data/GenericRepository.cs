using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.Data
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly WilliamHillContext _context;

        protected GenericRepository()
        {
            _context = new WilliamHillContext();
        }

        public WilliamHillContext Context
        {
            get { return _context; }
        }

        public Database Database
        {
            get { return _context.Database; }
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            var result = _context.SaveChanges();
        }
    }

    public interface IRepository<T> where T : class
    {
        Database Database { get; }

        int Count();
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
