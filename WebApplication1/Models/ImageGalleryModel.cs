using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web;

namespace WebApplication1.Models
{
    public class ImageGalleryModel
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public List<string> ImageList { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageToUpload { get; set; }

        public ImageGalleryModel()

        {
            ImageList = new List<string>();
        }
    }

    public class ImageDbConnectionContext : DbContext
    {
        public ImageDbConnectionContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ImageDbConnectionContext>());
            ImageGallery = Set<ImageGalleryModel>();
        }

        public DbSet<ImageGalleryModel> ImageGallery { get; set; }
    }
}