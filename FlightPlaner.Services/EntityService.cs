using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;
using FlightPlaner.Data;

namespace FlightPlaner.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IFlightPlanerDbContext context) : base(context)
        {
        }

        public T GetById(int id)
        {
            return GetById<T>(id);
        }

        public T Create(T entity)
        {
            return Create<T>(entity);
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public List<T> GetAll()
        {
            return GetAll<T>();
        }

        public void DeleteAll()
        {
            DeleteAll<T>();
        }
    }
}
