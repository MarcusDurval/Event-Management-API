using WebApi_System.Models;

namespace WebApi_System.EnrollmentRepository
{
    public interface IEnrollmentsRepository
    {
        Task<Enrollment> Add(Enrollment enrollment);
        Task<List<Enrollment>> Get();
        Task<Enrollment> Update(Enrollment enrollment);
        Task<Enrollment> Delete(int id);
        Task<Enrollment> GetId(int id);
    }
}
