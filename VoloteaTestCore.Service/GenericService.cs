using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Repository;
using VoloteaTestCore.Service.People;

namespace VoloteaTestCore.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }
        public void Insert(T entity)
        {
            _repository.Insert(entity);
            _repository.Save();
        }


        public void Update(T entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }

        public void Delete(object id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
