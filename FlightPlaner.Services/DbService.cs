using FlightPlaner.Core.Models;
using FlightPlaner.Core.Services;
using FlightPlaner.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlaner.Services
{
    public class DbService : IDbService
    {
        protected readonly IFlightPlanerDbContext _context;

        public DbService(IFlightPlanerDbContext context)
        {
            _context = context;
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public T Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }
    }
}
