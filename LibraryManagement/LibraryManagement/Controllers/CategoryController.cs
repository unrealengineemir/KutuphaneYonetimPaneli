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
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryRepository repo = new CategoryRepository();
        LibraryDBEntities1 db = new LibraryDBEntities1();
        public ActionResult Index(int page = 7)
        {
            var list = repo.List().Where(x => x.Situation == true).ToPagedList(page, 3);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Tbl_Category p)
        {
            p.Situation = true;
            repo.TAdd(p);   
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int id)
        {
            Tbl_Category find = repo.IFind(x => x.CategoryID == id);
            //repo.TDelete(find);
            find.Situation = false;
            repo.TUpdate(find);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Tbl_Category find = repo.IFind(x => x.CategoryID == id);
            return View(find);
        }

        [HttpPost]
        public ActionResult Update(Tbl_Category p)
        {
            Tbl_Category value = repo.IFind(x => x.CategoryID == p.CategoryID);
            value.Name = p.Name;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }

    }
}