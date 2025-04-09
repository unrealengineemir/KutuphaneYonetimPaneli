using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;


namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "A")]
    public class StatisticsController : Controller
    {
        // GET: Statistics
        LibraryDBEntities1 db = new LibraryDBEntities1();
        public ActionResult Index()
        {
            var casee = db.Tbl_Punishment.Sum(x => x.Money);
            var member = db.Tbl_Member.Count();
            var book = db.Tbl_Book.Count();
            var customerbook = db.Tbl_Book.Where(x => x.Situation == false).Count();

            ViewBag.casee = casee;
            ViewBag.member = member;
            ViewBag.customerbook = customerbook;
            ViewBag.book = book;

            return View();
        }

        public ActionResult Cards()
        {
            var value1 = db.Tbl_Book.Count();
            var value2 = db.Tbl_Member.Count();
            var value3 = db.Tbl_Punishment.Sum(x => x.Money);
            var value4 = db.Tbl_Book.Where(x => x.Situation == false).Count();
            var value5 = db.Tbl_Category.Count();
            var value6 = db.BOOKWRİTER().FirstOrDefault();
            var value7 = db.PublishinHouse().FirstOrDefault();
            var value8 = db.MAXBOOK().FirstOrDefault();
            var value9 = db.MAXMEMBER().FirstOrDefault();
            var value10 = db.MAXPERSONEL().FirstOrDefault();
            var value11 = db.Tbl_Message.Count();
            var value12 = db.TODAYBOOKS1().FirstOrDefault();

            ViewBag.value1 = value1;
            ViewBag.value2 = value2;
            ViewBag.value3 = value3;
            ViewBag.value4 = value4;
            ViewBag.value5 = value5;
            ViewBag.value6 = value6;
            ViewBag.value7 = value7;
            ViewBag.value8 = value8;
            ViewBag.value9 = value9;
            ViewBag.value10 = value10;
            ViewBag.value11 = value11;
            ViewBag.value12 = value12;

            return View();

        }


    }
}