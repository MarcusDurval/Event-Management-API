using Microsoft.EntityFrameworkCore;
using WebApi_System.Data;
using WebApi_System.EnrollmentDTO;
using WebApi_System.Models;

namespace WebApi_System.EnrollmentRepository
{
    public class EnrollmentsRepository : IEnrollmentsRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> Add(Enrollment enrollment)
        {
            _context.Enrollment.Add(enrollment); 
            await _context.SaveChangesAsync();

            return enrollment;
        }

        public async Task<Enrollment> Delete(int id)
        {
            var RemoveEnrollment = _context.Enrollment.FirstOrDefaultAsync(e => e.Id == id);

            _context.Remove(RemoveEnrollment);

            await _context.SaveChangesAsync();

            return await RemoveEnrollment;
        }

        public async Task<List<Enrollment>> Get()
        {
            return await _context.Enrollment
                .Include(e => e.Events)
                .Include(e => e.Participants)
                .ToListAsync();

            
        }

        public async Task<Enrollment> GetId(int id)
        {
            var IdEnrollment = await _context.Enrollment.FindAsync(id);

            return IdEnrollment;
        }

        public async Task<Enrollment> Update(Enrollment enrollment)
        {
            var existing = await _context.Enrollment.FindAsync(enrollment.Id);

            if (existing == null)
                return null;

            existing.EventId = enrollment.EventId;
            existing.ParticipantId = enrollment.ParticipantId;
            existing.RegistrationDate = enrollment.RegistrationDate;
            existing.Status = enrollment.Status;

            await _context.SaveChangesAsync();

            return existing;
        }
    }
}
