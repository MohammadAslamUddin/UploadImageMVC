using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace UploadImageMVC.Models
{
    public class ImageR
    {
        [Key]
        public int ImageID { get; set; }
        public string Title { get; set; }
        [DisplayName("Image Path")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}