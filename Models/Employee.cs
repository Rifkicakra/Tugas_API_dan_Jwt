﻿using System.ComponentModel.DataAnnotations;

namespace API_dan_JWT.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
