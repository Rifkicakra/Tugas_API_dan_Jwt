using API_dan_JWT.Context;
using API_dan_JWT.Models;
using System.Collections;
using API_dan_JWT.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using API_dan_JWT.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace API_dan_JWT.Repository
{
    public class DivisionRepositories : GeneralRepository<Division>
    {
        MyContext myContext;

        public DivisionRepositories(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpGet("Name")]
        public List<Division> Get(string name)
        {
            return myContext.Divisions.Where(x => x.Name == name).ToList();
        }


    }
}

