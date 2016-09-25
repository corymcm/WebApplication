using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class ImageGalleryModel
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public List<IImageModel> ImageList { get; set; }

        public ImageGalleryModel()

        {
            ImageList = new List<IImageModel>();
        }
    }

    public class ImageDbConnectionContext : DbContext
    {
        public ImageDbConnectionContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ImageDbConnectionContext>());
            ImageGallery = Set<UploadImageModel>();
        }

        public DbSet<UploadImageModel> ImageGallery { get; set; }
    }
}