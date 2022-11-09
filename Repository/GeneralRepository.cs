using API_dan_JWT.Repositories;
using API_dan_JWT.Context;
using API_dan_JWT.Repository.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_dan_JWT.Repository
{
    public class GeneralRepository<Entity> : IRepository<Entity>
     where Entity : class
    {
        MyContext myContext;
        
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Entity> Get()
        {
            var data = myContext.Set<Entity>().ToList();
            return data;
        }

        public Entity Get(int id)
        {
            var data = myContext.Set<Entity>().Find(id);
            return Get(id);
        }

        public int Create(Entity entity)
        {
            myContext.Set<Entity>().Add(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Update(Entity entity)
        {
            myContext.Set<Entity>().Update(entity);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
