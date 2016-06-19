using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class ImageGalleryModel
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public List<string> ImageList { get; set; }

        public ImageGalleryModel()

        {
            ImageList = new List<string>();
        }
    }

    public class ImageDbConnectionContext : DbContext
    {
        public ImageDbConnectionContext() : base("name=dbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ImageDbConnectionContext>());
        }

        public DbSet<ImageGalleryModel> ImageGallery { get; set; }
    }
}