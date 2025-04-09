using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "A")]

    public class AnnouncementController : Controller
    {
        // GET: Announcement
        LibraryDBEntities1 db = new LibraryDBEntities1();
        public ActionResult Index()
        {
            var list = db.Tbl_Announcement.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Tbl_Announcement a)
        {
            db.Tbl_Announcement.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var find = db.Tbl_Announcement.Find(id);
            db.Tbl_Announcement.Remove(find);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var find = db.Tbl_Announcement.Find(id);
            return View(find);

        }

        [HttpPost]
        public ActionResult Update(Tbl_Announcement a)
        {
            var find = db.Tbl_Announcement.Find(a.ID);
            find.Category = a.Category;
            find.Content = a.Content;
            find.Date = a.Date;
            db.SaveChanges();
             return RedirectToAction("Index");
        }

       
        public ActionResult Content(int id)
        {
            var value = db.Tbl_Announcement.Where(x => x.ID == id).FirstOrDefault();

            if (value != null)
            {
                ViewBag.content = value.Content;
                return View();
            }
            return View();
        }
    }
}