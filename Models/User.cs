using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_dan_JWT.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }

        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Roles { get; set; }

        public Employee Employee { get; set; }

    }

    //public class Jwt
    //{
    //    public string key { get; set; }
    //    public string Issuer { get; set; }
    //    public string Audience { get; set; }
    //    public string Subject { get; set; }

    //}
}
