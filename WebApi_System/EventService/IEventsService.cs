using WebApi_System.Models;

namespace WebApi_System.Service
{
    public interface IEventsService
    {
        Task<Event> Add(Event events);
        Task<List<Event>> GetAll();
        Task<Event> Delete(int id);
        Task<Event> Update(Event Events);
        Task<Event> GetID(int id);
    }
}
