using System.Text.Json.Serialization;

namespace WebApi_System.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; } = string.Empty;

        
        public Event Events { get; set; }
       
        public Participant Participants { get; set; }
    }
}
