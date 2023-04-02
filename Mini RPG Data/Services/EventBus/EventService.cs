namespace Mini_RPG_Data.Services.EventBus;

public class EventService : IEventService
{
    private readonly IDictionary<EventType, Action<EventType ,int>> _events = new Dictionary<EventType, Action<EventType, int>>();

    public void Subscribe(EventType eventType, Action<EventType, int> callback)
    {
        if (_events.TryGetValue(eventType, out Action<EventType, int> thisEvent))
        {
            thisEvent += callback;
        }
        else
        {
            thisEvent += callback;
            _events.Add(eventType, thisEvent);
        }
    }

    public void Unsubscribe(EventType type, Action<EventType, int> callback)
    {
        if (_events.TryGetValue(type, out Action<EventType, int> thisEvent))
        {
            thisEvent -= callback;
        }
    }

    public void Publish(EventType type, int index)
    {
        if (_events.TryGetValue(type, out Action<EventType, int> thisEvent))
        {
            thisEvent?.Invoke(type, index);
        }
    }
}

public enum EventType
{
    None,
    KilledEnemyWithId,
    KilledEnemyWithRace,
    MeetEnemyWithId,
    MeetEnemyWithRace,
    SpecialEventType,
}
