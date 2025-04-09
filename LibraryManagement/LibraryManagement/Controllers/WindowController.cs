using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;
using LibraryManagement.Repository;
using LibraryManagement.Models.Abstract;

namespace LibraryManagement.Controllers
{
    [AllowAnonymous]
    public class WindowController : Controller
    {
        // GET: Window
        BookRepository repo = new BookRepository();
        LibraryDBEntities1 db = new LibraryDBEntities1();
        Class1 cs = new Class1();

        [HttpGet]
        public ActionResult Index()
        {
            cs.Value1 = repo.List();
            cs.Value2 = db.Tbl_About.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Message m)
        {
            db.Tbl_Message.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}