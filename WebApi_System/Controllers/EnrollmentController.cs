using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_System.EnrollmentDTO;
using WebApi_System.EnrollmentService;
using WebApi_System.Models;

namespace WebApi_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DTOEnrollment enrollment)
        {
            var En = new Enrollment
            {
                EventId = enrollment.EventId,
                ParticipantId = enrollment.ParticipantId,
                RegistrationDate = enrollment.RegistrationDate,
                Status = enrollment.Status,
            };
            var createEnrollment = await _service.Add(En);

            return CreatedAtAction(nameof(GetById), new { id = En.Id }, createEnrollment);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var enrollment = await _service.Get();

            return Ok(enrollment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ennrollmentId = await _service.GetId(id);

            if(ennrollmentId == null)
            {
                return NotFound("Identifador Inválido, tente novamente.");
            }

            return Ok(ennrollmentId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,DTOEnrollment enrollment)
        {
            if (id != enrollment.Id)
                return BadRequest("Id inconsistente");

            var result = await _service.Update(enrollment);

            if (result == null)
            {
                return BadRequest("Ops! Erro: tente novamente");
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removeEnrollment = await _service.Delete(id);

            return Ok(removeEnrollment);
        }

    }
}
