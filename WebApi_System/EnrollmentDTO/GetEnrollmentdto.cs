using WebApi_System.Models;

namespace WebApi_System.EnrollmentDTO
{
    public class GetEnrollmentdto
    {
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; } = string.Empty;


        public Event Events { get; set; }

        public Participant Participants { get; set; }
    }
}
