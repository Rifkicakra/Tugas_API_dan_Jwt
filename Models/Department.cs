using API_dan_JWT.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_dan_JWT.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int DivisionID { get; set; }
        [ForeignKey("DivisionID")]
        [JsonIgnore]
        public Division? Divisions { get; set; }
    }
}