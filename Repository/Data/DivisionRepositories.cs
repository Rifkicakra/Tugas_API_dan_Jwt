using API_dan_JWT.Context;
using API_dan_JWT.Models;
using API_dan_JWT.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_dan_JWT.Repository
{
    public class DivisionRepositories : GeneralRepository<Division>
    {
        MyContext myContext;

        public DivisionRepositories(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public IEnumerable<Division> Get()
        {
            var data = myContext.Divisions.ToList();
            return data;
        }

        public Division GetById(int Id)
        {
            var data = myContext.Divisions.Find(Id);
            return data;
        }

        public int Create(Division Entity)
        {
            myContext.Divisions.Add(Entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Update(Division Entity)
        {
            myContext.Entry(Entity).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }

        public int Delete(int Id)
        {
            var data = myContext.Divisions.Find(Id);
            if (data != null)
            {
                myContext.Remove(data);
                var result = myContext.SaveChanges();
                return result;
            }
            return 0;
        }
    }
}
