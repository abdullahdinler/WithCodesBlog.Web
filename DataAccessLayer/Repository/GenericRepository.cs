using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly WithCodesContext _context;
        private readonly DbSet<T> _object;
        public GenericRepository(WithCodesContext context)
        {
            _context = context;
            _object = _context.Set<T>();
        }

        public List<T>? GetAll(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ? _object.ToList() : _object.Where(filter).ToList();
        }

        public T? GetById(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
           _context.Entry(entity).State = EntityState.Deleted;
           _context.SaveChanges();
        }
    }
}
