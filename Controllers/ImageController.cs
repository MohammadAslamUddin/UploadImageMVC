using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using UploadImageMVC.Manager;
using UploadImageMVC.Models;

namespace UploadImageMVC.Controllers
{
    public class ImageController : Controller
    {
        private ImageManager imageManager;

        public ImageController()
        {
            imageManager = new ImageManager();
        }

        [HttpGet]
        public ActionResult Image()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Image(ImageR image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Today.ToString("yymmdd") + extension;
            image.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            image.ImageFile.SaveAs(fileName);

            ViewBag.Save = imageManager.Save(image);

            return View();
        }
        //[HttpGet]
        //public ActionResult ImageView()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult ImageView(int id)
        {
            ImageR image = imageManager.Search(id);
            return View(image);
        }





        // GET: Image
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Image image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Today.ToString("yymmdd") + extension;
            image.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            image.ImageFile.SaveAs(fileName);

            using (DBModel db = new DBModel())
            {
                db.Images.Add(image);
                db.SaveChanges();
            }
            ModelState.Clear();

            return View();
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            Image image = new Image();
            using (DBModel db = new DBModel())
            {
                image = db.Images.Where(x => x.ImageID == id).FirstOrDefault();
            }
            return View(image);
        }
    }
}