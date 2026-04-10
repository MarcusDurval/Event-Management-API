using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi_System.EventDTO;
using WebApi_System.Models;
using WebApi_System.Service;

namespace WebApi_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _eventsService;
        public EventsController(IEventsService service)
        {
            _eventsService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventsService.GetAll();

            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DTOEvent eventDTO)
        {
           var ev = new Event
           {
               Title = eventDTO.Title,
               Description = eventDTO.Description,
               Datetime = eventDTO.DateTime,
               Location = eventDTO.Location,
               Maximum_Capacity = eventDTO.MaximumCapacity
           };
            var createEvent = await _eventsService.Add(ev);

            return CreatedAtAction(nameof(GetById), new {id = createEvent.Id}, createEvent);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventId = await _eventsService.GetID(id);

            return Ok(eventId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DTOEvent dto)
        {
            var eventUpdate = new Event
            {
                Id = id, 
                Title = dto.Title,
                Description = dto.Description,
                Datetime = dto.DateTime,
                Location = dto.Location,
                Maximum_Capacity = dto.MaximumCapacity
            };

            var updateEvent = await _eventsService.Update(eventUpdate);
            return Ok(updateEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var deletedEvent = await _eventsService.Delete(id);  

            return Ok(deletedEvent);
        }
    }
}
