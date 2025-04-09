using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;
using LibraryManagement.Repository;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "A")]
    public class BookTransactionsController : Controller
    {

        // GET: BookTransactions

        ProcessRepository repo = new ProcessRepository();
        LibraryDBEntities1 db = new LibraryDBEntities1();

        public ActionResult Index()
        {
            var list = repo.List().Where(x => x.TransactionStatus == false).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Transaction()
        {
            List<SelectListItem> book = (from i in db.Tbl_Book.Where(x => x.Situation == true).ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.Name,
                                             Value = i.BookID.ToString()

                                         }).ToList();
            ViewBag.book = book;



            List<SelectListItem> member = (from i in db.Tbl_Member.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.MemberID.ToString()

                                           }).ToList();


            ViewBag.member = member;


            List<SelectListItem> personel = (from i in db.Tbl_Personel.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.Fullname,
                                                 Value = i.PersonelID.ToString()

                                             }).ToList();



            ViewBag.personel = personel;

            return View();
        }

        [HttpPost]
        public ActionResult Transaction(Tbl_Process p)
        {

            var value1 = db.Tbl_Book.Where(x => x.BookID == p.Tbl_Book.BookID).FirstOrDefault();
            var value2 = db.Tbl_Member.Where(x => x.MemberID == p.Tbl_Member.MemberID).FirstOrDefault();
            var value3 = db.Tbl_Personel.Where(x => x.PersonelID == p.Tbl_Personel.PersonelID).FirstOrDefault();

            p.Tbl_Book = value1;
            p.Tbl_Member = value2;
            p.Tbl_Personel = value3;
            db.Tbl_Process.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult TransactionUpdate(int id)
        {
            var result = repo.IFind(x => x.ProcessID == id);
            DateTime d1 = Convert.ToDateTime(result.ReturnDate.ToString());
            DateTime d2 = DateTime.Parse(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;

            if (d3.Days <= 0)
            {
                ViewBag.date = 0;
            }
            else
            {
                ViewBag.date = d3.TotalDays;
            }

            return View("TransactionUpdate", result);
        }

        public ActionResult Update(Tbl_Process p)
        {
            var prc = repo.IFind(x => x.ProcessID == p.ProcessID);
            prc.BroughDate = p.BroughDate;
            prc.TransactionStatus = true;
            repo.TUpdate(prc);
            return RedirectToAction("Index");
        }

    }
}