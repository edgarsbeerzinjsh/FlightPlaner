using FlightPlaner.Core.Models;

namespace FlightPlaner.Core.Services
{
    public interface IEntityService<T> : IDbService where T : Entity
    {
        public T GetById(int id);
        public T Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public List<T> GetAll();
    }
}
