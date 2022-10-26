namespace Mini_RPG_Data.Services.EventBus;

public interface IEventService : IService
{
    void Publish(EventType type, int index);
    void Subscribe(EventType eventType, Action<EventType, int> callback);
    void Unsubscribe(EventType type, Action<EventType, int> callback);
}
