using API_dan_JWT.Context;
using API_dan_JWT.Models;
using API_dan_JWT.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API_dan_JWT.Repository.Data
{
    public class DepartmentRepositories : GeneralRepository<Department>
    {
        MyContext myContext;

        public DepartmentRepositories(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        [HttpGet("DepartmentName")]
        public List<Department> Get(string name)
        {
            return myContext.Departments.Where(x => x.Name == name).ToList();
        }

        internal object GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}