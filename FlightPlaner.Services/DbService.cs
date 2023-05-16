using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;

namespace FlightPlaner.Services
{
    public class DbService : IDbService
    {
        public void Create<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
