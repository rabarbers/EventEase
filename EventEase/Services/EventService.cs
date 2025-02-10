using EventEase.Models;

namespace EventEase.Services;

public class EventService
{
    private readonly List<Event> _events =
    [
        new Event
        {
            EventId = 1, EventName = "Tech Conference", EventDate = "2025-02-15", EventLocation = "Riga, Latvia"
        },
        new Event
        {
            EventId = 2, EventName = "Music Festival", EventDate = "2025-03-10", EventLocation = "Tallinn, Estonia"
        }
    ];

    public List<Event> GetEvents()
    {
        return _events;
    }

    public Event? GetEventById(int eventId)
    {
        return _events.Find(e => e.EventId == eventId);
    }

    public void AddEvent(Event newEvent)
    {
        _events.Add(newEvent);
    }

    public void UpdateEvent(Event updatedEvent)
    {
        var existingEvent = GetEventById(updatedEvent.EventId);
        if (existingEvent == null) return;
        existingEvent.EventName = updatedEvent.EventName;
        existingEvent.EventDate = updatedEvent.EventDate;
        existingEvent.EventLocation = updatedEvent.EventLocation;
    }
}