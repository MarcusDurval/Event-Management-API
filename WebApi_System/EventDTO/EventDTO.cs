using System.Text.Json.Serialization;

namespace WebApi_System.EventDTO
{
    public class DTOEvent
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public string Location { get; set; }
        [JsonPropertyName("Maximum_Capacity")]
        public int MaximumCapacity { get; set; }
    }
}
