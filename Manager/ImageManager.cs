using UploadImageMVC.Gateway;
using UploadImageMVC.Models;

namespace UploadImageMVC.Manager
{
    public class ImageManager
    {
        private ImageGateway imageGateway;

        public ImageManager()
        {
            imageGateway = new ImageGateway();
        }

        public string Save(ImageR image)
        {
            int rowAffected = imageGateway.Save(image);
            if (rowAffected > 0) return "Saved!";
            else return "Saving Failed!";
        }

        public ImageR Search(int id)
        {
            return imageGateway.Search(id);
        }
    }
}