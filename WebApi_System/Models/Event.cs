using System.Text.Json.Serialization;

namespace WebApi_System.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Datetime { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Maximum_Capacity { get; set; }
        [JsonIgnore]
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}
