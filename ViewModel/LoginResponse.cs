using System.Text.Json.Serialization;
using API_dan_JWT.Models;

namespace API_dan_JWT.ViewModel
{
    public class LoginResponse
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        [JsonIgnore]
        public Role? role { get; set; }

        public int Role { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
