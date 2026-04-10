using Microsoft.EntityFrameworkCore;
using WebApi_System.Data;
using WebApi_System.Models;

namespace WebApi_System.ParticipantRepository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AppDbContext _context;

        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Participant> Add(Participant participant)
        {
            _context.Participant.Add(participant);

            await _context.SaveChangesAsync();

            return participant;
        }

        public async Task<Participant> Delete(int id)
        {
            var participant = await _context.Participant.FirstOrDefaultAsync(p => p.Id == id);

            _context.Participant.Remove(participant);

            await _context.SaveChangesAsync();

            return participant;

        }

        public async Task<List<Participant>> Get()
        {
            return await _context.Participant.ToListAsync();
        }

        public async Task<Participant> GetId(int id)
        {
            var participantId = await _context.Participant.FindAsync(id);

            return participantId;
        }

        public async Task<Participant> Update(Participant participant)
        {
            var updateParticipant = await _context.Participant.FindAsync(participant.Id);

            if(updateParticipant == null)
            {
                return null;
            }
            updateParticipant.Name = participant.Name;
            updateParticipant.Email = participant.Email;
            updateParticipant.DateRegistration = participant.DateRegistration;


            await _context.SaveChangesAsync();

            return updateParticipant;
        }
    }
}
