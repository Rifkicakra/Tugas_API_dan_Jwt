using System.ComponentModel.DataAnnotations;

namespace API_dan_JWT.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
