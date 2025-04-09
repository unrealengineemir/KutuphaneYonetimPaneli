using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        LibraryDBEntities1 db = new LibraryDBEntities1();
        public ActionResult Index()
        {
            var value = (string)Session["Mail"];
            var find = db.Tbl_Member.FirstOrDefault(x => x.Mail == value);
            return View(find);
        }
    }
}