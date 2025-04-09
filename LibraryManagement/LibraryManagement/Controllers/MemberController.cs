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
    public class MemberController : Controller
    {
        // GET: Member
        MemberRepository repo = new MemberRepository();
        ProcessRepository repo2 = new ProcessRepository();

        public ActionResult Index(int page = 1)
        {
            var list = repo.List().ToPagedList(page,7);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Tbl_Member m)
        {
            repo.TAdd(m);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var value = repo.IFind(x=>x.MemberID==id);
            repo.TDelete(value);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = repo.IFind(x => x.MemberID == id);
            return View(value);
        }

        [HttpPost]

        public ActionResult Update(Tbl_Member m)
        {
            var value = repo.IFind(x => x.MemberID == m.MemberID);
            value.Name = m.Name;
            value.Surname = m.Surname;
            value.Mail = m.Mail;
            value.Username = m.Username;
            value.Password = m.Password;
            value.Photo = m.Photo;
            value.Telephone = m.Telephone;
            value.School = m.School;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var value = repo2.List().Where(x => x.Member == id).ToList();
            var find = repo.IFind(x => x.MemberID == id);
            ViewBag.name = find.Name;
            ViewBag.surname = find.Surname;
            return View(value);
        }

    }
}