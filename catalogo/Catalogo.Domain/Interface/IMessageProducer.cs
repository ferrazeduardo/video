using System;

namespace Catalogo.Domain.Interface;

public interface IMessageProducer
{
    Task SendMessageAsync<T>(T message);
}
