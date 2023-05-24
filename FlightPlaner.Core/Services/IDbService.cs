using FlightPlaner.Core.Models;

namespace FlightPlaner.Core.Services
{
    public interface IDbService
    {
        public T GetById<T>(int id) where T : Entity;
        public T Create<T>(T entity) where T : Entity;
        public void Update<T>(T entity) where T : Entity;
        public void Delete<T>(T entity) where T : Entity;
        public List<T> GetAll<T>() where T : Entity;
        public void DeleteAll<T>() where T : Entity;
    }
}
