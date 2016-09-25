using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace WebApplication1.Models
{
    public class UploadImageModel : IImageModel
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageToUpload { get; set; }
    }
}