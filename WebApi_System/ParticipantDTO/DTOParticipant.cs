using System.ComponentModel.DataAnnotations;

namespace WebApi_System.ParticipantDTO
{
    public class DTOParticipant
    {
        public string Name { get; set; } = string.Empty;
        
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
