using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;
using LibraryManagement.Repository;
using PagedList.Mvc;
using PagedList;


namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "A")]
    public class WriterController : Controller
    {
        // GET: Writer
        WriterRepository repo = new WriterRepository();
        BookRepository repo2 = new BookRepository();

        public ActionResult Index(int page = 1)
        {
            var list = repo.List().ToPagedList(page, 3);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Tbl_Writer p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            var find = repo.IFind(x => x.WriterID == id);
            repo.TDelete(find);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            var find = repo.IFind(x => x.WriterID == id);
            return View(find);

        }

        [HttpPost]
        public ActionResult Update(Tbl_Writer b)
        {
            Tbl_Writer value = repo.IFind(x => x.WriterID == b.WriterID);
            value.Name = b.Name;
            value.Surname = b.Surname;
            value.Detail = b.Detail;
            repo.TUpdate(value);
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            var value = repo2.List().Where(x => x.Writer == id).ToList();
            var find = repo.IFind(x =>x.WriterID == id);
            ViewBag.name = find.Name;
            ViewBag.surname = find.Surname;
            return View(value);

        }

    }
}