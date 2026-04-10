using WebApi_System.Models;

namespace WebApi_System.ParticipantRepository
{
    public interface IParticipantRepository
    {
        Task<Participant> Add(Participant participant);
        Task<Participant> Update(Participant participant);
        Task<Participant> Delete(int id);
        Task<List<Participant>> Get();
        Task<Participant> GetId(int id); 
    }
}
