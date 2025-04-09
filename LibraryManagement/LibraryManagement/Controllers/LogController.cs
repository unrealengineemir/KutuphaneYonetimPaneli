using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;
using System.Web.Security;


namespace LibraryManagement.Controllers
{
   [AllowAnonymous]
    public class LogController : Controller
    {
        // GET: Log
        LibraryDBEntities1 db = new LibraryDBEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Member m)
        {
            var values = db.Tbl_Member.FirstOrDefault(x => x.Mail == m.Mail && x.Password == m.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Mail, false);           
                TempData["Name"] = values.Name.ToString();
                TempData["Surname"] = values.Surname.ToString();
                Session["Mail"] = values.Mail.ToString();
                Session["Photo"] = values.Photo.ToString();
               

                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }

    }
}