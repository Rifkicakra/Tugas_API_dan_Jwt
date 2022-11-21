using API_dan_JWT.Repositories;
using API_dan_JWT.Context;
using API_dan_JWT.Repository.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_dan_JWT.Repository
{
    public class GeneralRepository<Entity> : IRepository<Entity> where Entity : class
    {
        MyContext myContext;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Create(Entity entity)
        {
            myContext.Set<Entity>().Add(entity);
            var data = myContext.SaveChanges();
            return data;
        }

        public int Delete(int Id)
        {
            var data = Get(Id);
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public IEnumerable<Entity> Get()
        {
            var data = myContext.Set<Entity>().ToList();
            return data;

        }

        public Entity Get(int Id)
        {
            var data = myContext.Set<Entity>().Find(Id);
            return data;
        }

        public int Update(Entity entity)
        {
            myContext.Set<Entity>().Update(entity);
            var result = myContext.SaveChanges();
            return result;
        }


    }
}