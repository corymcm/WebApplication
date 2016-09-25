using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LocalImageModel : IImageModel
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public LocalImageModel(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
        }
    }
}