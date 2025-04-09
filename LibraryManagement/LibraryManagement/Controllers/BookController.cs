using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;
using LibraryManagement.Repository;
using PagedList;
using PagedList.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "A")]

    public class BookController : Controller
    {
        // GET: Book
        LibraryDBEntities1 db = new LibraryDBEntities1();
        BookRepository repo = new BookRepository();

        public ActionResult Index(int page = 1)
        {
            var list = repo.List().ToPagedList(page, 7);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> value1 = (from i in db.Tbl_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.CategoryID.ToString(),

                                           }
                                           ).ToList();

            List<SelectListItem> value2 = (from i in db.Tbl_Writer.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + " " + i.Surname,
                                               Value = i.WriterID.ToString()
                                           }
                                           ).ToList();


            ViewBag.v1 = value1;
            ViewBag.v2 = value2;
            return View();

        }

        [HttpPost]

        public ActionResult Add(Tbl_Book b)
        {
            var ctgry = db.Tbl_Category.Where(x => x.CategoryID == b.Tbl_Category.CategoryID).FirstOrDefault();
            var wrtr = db.Tbl_Writer.Where(x => x.WriterID == b.Tbl_Writer.WriterID).FirstOrDefault();
            b.Tbl_Category = ctgry;
            b.Tbl_Writer = wrtr;
            b.Situation = true;
            db.Tbl_Book.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            var find = repo.IFind(x => x.BookID == id);
            repo.TDelete(find);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var find = repo.IFind(x => x.BookID == id);

            List<SelectListItem> item1 = (from i in db.Tbl_Category.ToList()
                                          select new SelectListItem
                                          {

                                              Text = i.Name,
                                              Value = i.CategoryID.ToString()
                                          }

                                          ).ToList();

            List<SelectListItem> item2 = (from i in db.Tbl_Writer.ToList()
                                          select new SelectListItem
                                          {

                                              Text = i.Name + " " + i.Surname,
                                              Value = i.WriterID.ToString()

                                          }
                                          ).ToList();



            ViewBag.item1 = item1;
            ViewBag.item2 = item2;

            return View(find);
        }

        [HttpPost]
        public ActionResult Update(Tbl_Book b)
        {
            var find = repo.IFind(x => x.BookID == b.BookID);
            find.Name = b.Name;
            find.Year = b.Year;
            find.PublishingHouse = b.PublishingHouse;
            find.Page = b.Page;

            var ctgr = db.Tbl_Category.Where(x => x.CategoryID == b.Tbl_Category.CategoryID).FirstOrDefault();
            find.Category = ctgr.CategoryID;

            var wrtr = db.Tbl_Writer.Where(x => x.WriterID == b.Tbl_Writer.WriterID).FirstOrDefault();
            find.Writer = wrtr.WriterID;
            repo.TUpdate(find);
            return RedirectToAction("Index");

        }

    }
}