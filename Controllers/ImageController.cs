using System.Web.Mvc;

namespace UploadImageMVC.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}