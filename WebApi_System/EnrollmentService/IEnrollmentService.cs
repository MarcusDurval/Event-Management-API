using WebApi_System.EnrollmentDTO;
using WebApi_System.Models;

namespace WebApi_System.EnrollmentService
{
    public interface IEnrollmentService
    {
        Task<Enrollment> Add(Enrollment enrollment);
        Task<List<Enrollment>> Get();
        Task<Enrollment> Update(DTOEnrollment enrollment);
        Task<Enrollment> Delete(int id);
        Task<Enrollment> GetId(int id);
    }
}
