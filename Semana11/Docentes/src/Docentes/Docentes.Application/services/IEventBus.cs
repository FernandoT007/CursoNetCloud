namespace Docentes.Application.services;

public interface IEventBus
{
    void Consume<T>() where T : class;
    void Publish<T>(T @event) where T : class;
}