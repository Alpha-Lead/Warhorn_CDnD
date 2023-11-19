namespace Warhorn.API.Types
{
    public class Slot //: Node
    {
        public string? id;

        public DateTime? endsAt;
        public Event? _event;
        public List<EventSessionConnection>? sessions;
        public DateTime? startsAt;
        public string? timezone;
        public Venue venue;
    }
}