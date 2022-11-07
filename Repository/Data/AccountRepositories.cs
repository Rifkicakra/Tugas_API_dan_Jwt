﻿using API_dan_JWT.Context;
using API_dan_JWT.Handler;
using API_dan_JWT.Models;
using API_dan_JWT.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_dan_JWT.Repositories
{
    public class AccountRepositories : IRepository<User, int>
    {
        private readonly MyContext myContext;

        public AccountRepositories(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Create(User entity)
        {
            myContext.Users.Add(entity);
            var data = myContext.SaveChanges();
            return data;
        }

        public int Delete(int Id)
        {
            var data = myContext.Users.Find(Id);
            if (data != null)
            {
                myContext.Users.Remove(data);
                var result = myContext.SaveChanges();
                return result;
            }
            return 0;
        }

        public ICollection<User> Get()
        {
            return myContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return myContext.Users.Find(id);
        }

        public int Update(User entity)
        {
            myContext.Entry(entity).State = EntityState.Modified;
            var data = myContext.SaveChanges();
            return data;
        }


        public int Register(string fullname, string email, DateTime birthdate, string password)
        {

            if (myContext.Employees.Any(x => x.Email == email))
            {
                return 0;
            }

            Employee employee = new Employee()
            {
                FullName = fullname,
                Email = email,
                BirthDate = birthdate
            };
            myContext.Employees.Add(employee);
            var create = myContext.SaveChanges();

            if (create > 0)
            {
                var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                User user = new User()
                {
                    Id = id,
                    Password = Hashing.HashPassword(password),
                    RoleId = 1
                };

                myContext.Users.Add(user);
                var result = myContext.SaveChanges();
                if (result > 1)
                {
                    return result;
                }
            }
            return 1;
        }

        public int Login(string email, string password)
        {
            var data = myContext.Users.Include(x => x.Employee).Include(x => x.Role)
               .SingleOrDefault(x => x.Employee.Email == email);

            if (data != null)
            {
                var vp = Hashing.ValidatePassword(password, data.Password);
                if (vp == true)
                    return 1;
            }

            return 0;
        }

        public int ChangePassword(string pw, string password, string email)
        {
            var data = myContext.Users.Include(x => x.Employee).FirstOrDefault(x => x.Employee.Email.Equals(email));
            var validate = Hashing.ValidatePassword(pw, data.Password);
            if (data != null && validate == true)
            {

                data.Password = Hashing.HashPassword(password);
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return 1;

            }

            return 0;
        }


        public int ForgotPassword(string fullName, string email, string birthDate, string newPassword)
        {
            var data = myContext.Users
                          .Include(x => x.Employee)
                          .SingleOrDefault(x => x.Employee.Email
                          .Equals(email) && x.Employee.FullName.Equals(fullName) && x.Employee.BirthDate.Equals(birthDate));

            if (data != null)
            {


                User user = new User()
                {
                    Password = newPassword
                };

                data.Password = user.Password;
                myContext.Entry(data).State = EntityState.Modified;
                myContext.SaveChanges();


                return 1;
            }


            return 0;
        }


    }
}