namespace Mini_RPG_Data.Services.EventBus;

public interface IEventService : IService
{
    void Publish(EventType type, string arg);
    void Subscribe(EventType eventType, Action<EventType, string> callback);
    void Unsubscribe(EventType type, Action<EventType, string> callback);
}
