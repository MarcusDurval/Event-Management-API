using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi_System.Data;
using WebApi_System.EnrollmentDTO;
using WebApi_System.EnrollmentRepository;
using WebApi_System.Models;

namespace WebApi_System.EnrollmentService
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentsRepository _repository;
        private readonly AppDbContext _context; 

        public EnrollmentService(IEnrollmentsRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Enrollment> Add(Enrollment enrollment)
        {
            if (enrollment == null) throw new ArgumentNullException(nameof(enrollment));

            await _repository.Add(enrollment);

            return enrollment;

        }

        public async Task<Enrollment> Delete(int id)
        {
            var serviceRemove = _repository.GetId(id);

            if(serviceRemove == null)
            {
                throw new Exception($"Inscrição {id} não encontrado");
            }

            return await _repository.Delete(id);
        }

        public async Task<List<Enrollment>> Get()
        {
            return await _repository.Get();

        }

        public Task<Enrollment> GetId(int id)
        {
           var serviceId = _repository.GetId(id);

            if(serviceId == null)
            {
                throw new Exception($"Inscrição com ID: {id} não encontrado.");
            }

            return serviceId;   
        }

        public async Task<Enrollment> Update(DTOEnrollment enrollment)
        {
           var existing = await _repository.GetId(enrollment.Id);

           if(existing == null)
           {
                throw new Exception($"Inscrição Não encontrada {enrollment.Id}");
           }

            var exists = await _context.Enrollment.AnyAsync(e =>
            e.EventId == enrollment.EventId &&
            e.ParticipantId == enrollment.ParticipantId &&
            e.Id != enrollment.Id);

            if (enrollment == null)
            {
                throw new ArgumentNullException(nameof(enrollment));
            }

            if (exists)
            {
                throw new Exception("Participante já inscrito neste evento.");
            }
                

            existing.EventId = enrollment.EventId;
            existing.ParticipantId = enrollment.ParticipantId;
            existing.RegistrationDate = enrollment.RegistrationDate;
            existing.Status = enrollment.Status;
           
            
            return await _repository.Update(existing);


        }
    }
}
