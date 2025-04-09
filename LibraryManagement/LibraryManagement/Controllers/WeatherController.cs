using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "A")]
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weather()
        {

            return View();

        }

        public ActionResult Slider()
        {
            return View();
        }


        public ActionResult UploadImages(HttpPostedFileBase dosyasec)
        {
            if (dosyasec.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/İmages/"), Path.GetFileName(dosyasec.FileName));
                dosyasec.SaveAs(dosyayolu);

            }
            return RedirectToAction("Slider");
        }


    }
}