using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using WebApi_System.Data;
using WebApi_System.Models;

namespace WebApi_System.Repositoryt
{
    public class EventsRepository : IEventsRepository
    {
        private readonly AppDbContext _context;

        public EventsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Event> Add(Event events)
        {
            _context.Event.Add(events);
            await _context.SaveChangesAsync();
            return events;
        }

        public async Task<Event> Delete(int id)
        {
            var eventToRemove = await _context.Event.FirstOrDefaultAsync(e => e.Id == id);

            if (eventToRemove != null)
            {
                _context.Event.Remove(eventToRemove);
                await _context.SaveChangesAsync();
            }

          
            return eventToRemove;
        }

        public async Task<List<Event>> GetAll()
        {
            return await _context.Event.ToListAsync();
        }

        public async Task<Event> GetID(int id)
        {
            var IdEvents = await _context.Event.FindAsync(id);

            return IdEvents;

        }

        public async Task<Event> Update(Event Events)
        {
            var UpdateEvents = await _context.Event.FindAsync(Events.Id);

            if(UpdateEvents != null)
            {

                UpdateEvents.Title = Events.Title;
                UpdateEvents.Description = Events.Description;
                UpdateEvents.Datetime = Events.Datetime;
                UpdateEvents.Location = Events.Location;
                UpdateEvents.Maximum_Capacity = Events.Maximum_Capacity;

                await _context.SaveChangesAsync();

            }

            return Events;  
        }
    }
}
