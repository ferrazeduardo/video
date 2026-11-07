using System;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Domain.Events;

public class VideoUploadedEvent : DomainEvent
{
    public VideoUploadedEvent(int resourceId, string filePath) : base()
    {
        ResourceId = resourceId;
        FilePath = filePath;
    }

    public int ResourceId { get; set; }
    public string FilePath { get; set; }
}
