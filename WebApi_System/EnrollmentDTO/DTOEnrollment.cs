namespace WebApi_System.EnrollmentDTO
{
    public class DTOEnrollment
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
