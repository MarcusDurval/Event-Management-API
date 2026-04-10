using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi_System.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateRegistration { get; set; }
        [JsonIgnore]
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}
