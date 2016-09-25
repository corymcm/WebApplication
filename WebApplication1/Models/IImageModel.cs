using System;

namespace WebApplication1.Models
{
    public interface IImageModel
    {
        Guid ID { get; set; }

        string Name { get; set; }
    }
}
