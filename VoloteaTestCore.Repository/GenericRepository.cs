using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.EF;

namespace VoloteaTestCore.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private PeopleDbContext _context = null;
        private DbSet<T> _entity = null;
        public GenericRepository()
        {
            this._context = new PeopleDbContext();
            _entity = _context.Set<T>();
        }
        public GenericRepository(PeopleDbContext _context)
        {
            this._context = _context;
            _entity = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }
        public T GetById(object id)
        {
            return _entity.Find(id);
        }
        public void Insert(T obj)
        {
            _entity.Add(obj);
        }
        public void Update(T obj)
        {
            _entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = _entity.Find(id);
            _entity.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
