using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "A")]
    public class GrapchicsController : Controller
    {
        // GET: Grapchics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Charts()
        {

            return Json(list());

        }

        public List<Class1> list()
        {
            List<Class1> c = new List<Class1>();

            c.Add(new Class1()
            {
                PublishingHouse = "Mars",
                Piece =4

            });

            c.Add(new Class1()
            {
                PublishingHouse = "Jüpiter",
                Piece = 2

            });

            c.Add(new Class1()
            {
                PublishingHouse = "Satürn",
                Piece = 3

            });

            return c;
        }
    }
}