using System.Collections.Generic;
using System.Linq;
using WebApiCore.Data.Context;
using WebApiCore.Data.Models;

namespace WebApiCore.Data.Repository
{
    public class WeatherRepository : IRepository<CurrentWeather>
    {
        private readonly WebApiCoreContext context;

        public IEnumerable<CurrentWeather> All => context.Weathers.ToList();

        public WeatherRepository(WebApiCoreContext context) 
        {
            this.context = context;
        }
        public void Add(CurrentWeather entity)
        {
            context.Weathers.Add(entity);
        }

        public void Delete(CurrentWeather entity)
        {
            context.Weathers.Remove(entity);
            context.SaveChanges();
        }

        public CurrentWeather FindById(int Id)
        {
            return context.Weathers.FirstOrDefault(e => e.Id == Id);
        }

        public void Update(CurrentWeather entity)
        {
            context.Weathers.Update(entity);
            context.SaveChanges();
        }

        public CurrentWeather FindById(string Id)
        {
            throw new System.NotImplementedException();
        }
    }
}