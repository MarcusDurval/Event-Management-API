using Microsoft.Extensions.Logging;
using WebApi_System.Models;
using WebApi_System.ParticipantRepository;

namespace WebApi_System.ParticipantService
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _repository;

        public ParticipantService(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Participant> Add(Participant participant)
        {
            if (participant == null)
            {
                throw new ArgumentNullException(nameof(participant));
            }

             await _repository.Add(participant);

            return participant;
        }

        public async Task<Participant> Delete(int id)
        {
            var participant = _repository.GetId(id);

            if (participant == null)
            {
                throw new Exception($"Participante {id} não encontrado");
            }

            return await _repository.Delete(id); 
        }

        public async Task<List<Participant>> GetAll()
        {
            return await _repository.Get();
        }

        public Task<Participant> GetId(int id)
        {
            var participant = _repository.GetId(id);

            if (participant == null)
            {
                throw new Exception($"Participante {id} não encontrado");
            }

            return participant; 
        }

        public async Task<Participant> Update(Participant participant)
        {
            var updateParticipant = await _repository.GetId(participant.Id);

            if(updateParticipant == null)
            {
                throw new Exception($"Participante {participant.Id} não encontrado");
            }
            if (participant == null)
            {
                throw new ArgumentNullException(nameof(participant));

            }

            updateParticipant.Name = participant.Name;
            updateParticipant.Email = participant.Email;
            updateParticipant.DateRegistration = participant.DateRegistration;
            
            return await _repository.Update(updateParticipant);


        }
    }
}
