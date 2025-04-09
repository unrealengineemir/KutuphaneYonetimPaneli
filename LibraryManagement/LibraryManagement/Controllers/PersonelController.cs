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
    public class PersonelController : Controller
    {
        // GET: Personel
        PersonelRepository repo = new PersonelRepository();
        public ActionResult Index(int page = 1)
        {
            var list = repo.List().ToPagedList(page,3);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Add(Tbl_Personel p)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var value = repo.IFind(x => x.PersonelID == id);
            repo.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = repo.IFind(x => x.PersonelID == id);
            return View(value);

        }

        [HttpPost]
        public ActionResult Update(Tbl_Personel p)
        {
            var value = repo.IFind(x => x.PersonelID == p.PersonelID);
            value.Fullname = p.Fullname;

            if (!ModelState.IsValid)
            {
                return View();
            }

            repo.TUpdate(value);
            return RedirectToAction("Index");
        }

    }
}