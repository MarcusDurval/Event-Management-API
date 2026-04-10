using WebApi_System.Models;

namespace WebApi_System.ParticipantService
{
    public interface IParticipantService
    {
        Task<Participant>Add(Participant participant);
        Task<List<Participant>> GetAll();
        Task<Participant>Update(Participant participant);
        Task<Participant>Delete(int id);
        Task<Participant> GetId(int id);
    }
}
