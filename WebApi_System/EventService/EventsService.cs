using WebApi_System.Models;
using WebApi_System.Repositoryt;

namespace WebApi_System.Service
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _Repository;

        public EventsService(IEventsRepository repository)
        {
            _Repository = repository;
        }

        public async Task<Event> Add(Event events)
        {
            if(events == null) throw new ArgumentNullException(nameof (events));

            if(string.IsNullOrWhiteSpace(events.Title)) throw new ArgumentNullException("Por Favor, preencha o campo corretamente.");

            await _Repository.Add(events);
            
            return events;
        }

        public async Task<Event> Delete(int id)
        {
           var ServiceEvents = await _Repository.GetID(id);  

            if(ServiceEvents == null)
            {
                throw new Exception($"Evento {id} não encontrado");
            }

            return await _Repository.Delete(id);
        }

        public async Task<List<Event>> GetAll()
        {
            return await _Repository.GetAll();
        }

        public async Task<Event> GetID(int id)
        {
            var ServiceEvents = await _Repository.GetID(id);  

            if(ServiceEvents == null)
            {
                throw new Exception($"Evento com ID {id} não encontrado.");
            }

            return ServiceEvents;
        }

        public async Task<Event> Update(Event Events)
        {
            if (Events == null) throw new ArgumentNullException(nameof(Events));

            var ServiceEvent = await _Repository.GetID(Events.Id);

            ServiceEvent.Title = Events.Title;
            ServiceEvent.Description = Events.Description;
            ServiceEvent.Datetime = Events.Datetime;
            ServiceEvent.Location = Events.Location;
            ServiceEvent.Maximum_Capacity = Events.Maximum_Capacity;

            if (ServiceEvent == null) throw new Exception("Não encontrado!");

            return await _Repository.Update(Events);
        }
    }
}
