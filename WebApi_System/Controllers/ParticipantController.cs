using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_System.EnrollmentService;
using WebApi_System.Models;
using WebApi_System.ParticipantDTO;
using WebApi_System.ParticipantService;

namespace WebApi_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _service;

        public ParticipantController(IParticipantService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DTOParticipant participant)
        {
            var pt = new Participant
            {
                Name = participant.Name,
                Email = participant.Email,
            };
            var createParticipant = await _service.Add(pt);

            return CreatedAtAction(nameof(GetById), new { id = pt.Id }, createParticipant);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var participant = await _service.GetAll();

            return Ok(participant);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var participant = await _service.GetId(id);

            if (participant == null)
            {
                return BadRequest("Error ao encontra o identificador!");
            }

            return Ok(participant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Participant participant)
        {
            id = participant.Id;

            var update = await _service.Update(participant);
            if (update == null)
            {
                return BadRequest($"Ops! Erro:{update} tente novamente");
            }
            return Ok(update);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var remove = await _service.Delete(id);

            return Ok(remove);  
        }
    }
}
