﻿namespace Mini_RPG_Data.Services.EventBus;

public class EventService : IEventService
{
    private readonly IDictionary<EventType, Action<EventType, string>> _events = new Dictionary<EventType, Action<EventType, string>>();

    public void Subscribe(EventType eventType, Action<EventType, string> callback)
    {
        if (_events.TryGetValue(eventType, out Action<EventType, string> thisEvent))
        {
            thisEvent += callback;
        }
        else
        {
            thisEvent += callback;
            _events.Add(eventType, thisEvent);
        }
    }

    public void Unsubscribe(EventType type, Action<EventType, string> callback)
    {
        if (_events.TryGetValue(type, out Action<EventType, string> thisEvent))
        {
            thisEvent -= callback;
        }
    }

    public void Publish(EventType type, string arg)
    {
        if (_events.TryGetValue(type, out Action<EventType, string> thisEvent))
        {
            thisEvent?.Invoke(type, arg);
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
