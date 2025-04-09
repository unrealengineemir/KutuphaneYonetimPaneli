using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryManagement.Models.Entity;



namespace LibraryManagement.Controllers
{
    
    public class PanelController : Controller
    {
        // GET: Panel
        LibraryDBEntities1 db = new LibraryDBEntities1();

        public ActionResult Index()
        {
            var value = (string)Session["Mail"];
            Tbl_Member find = db.Tbl_Member.FirstOrDefault(x => x.Mail == value);
            var information = db.Tbl_Member.Where(x => x.Mail == value).FirstOrDefault();


            ViewBag.name = information.Name;
            ViewBag.surname = information.Surname;
            ViewBag.photo = information.Photo;
            ViewBag.sc = information.School;


            var memberid = db.Tbl_Process.Where(x => x.Member == information.MemberID).Count();
            ViewBag.id = memberid;


            var lastbook = db.Tbl_Process
                .Where(x => x.Member == information.MemberID)
                .OrderByDescending(x => x.ProcessID)
                .Select(x => x.Book)
                .FirstOrDefault();

            var book = db.Tbl_Book.Where(x => x.BookID == lastbook).FirstOrDefault();
            ViewBag.book = book.Name;

            var message = db.Tbl_Contact.Where(x => x.Buyer == information.Mail).Count();
            ViewBag.message = message;

            return View(find);
        }

        [HttpPost]
        public ActionResult Index2(Tbl_Member m)
        {
            var mail = (string)Session["Mail"];
            var update = db.Tbl_Member.FirstOrDefault(x => x.Mail == mail);

            update.Password = m.Password;
            update.Name = m.Name;
            update.Surname = m.Surname;
            update.Username = m.Username;
            update.Telephone = m.Telephone;
            update.School = m.School;

            db.SaveChanges();
            return RedirectToAction("Index", "Panel");
        }

        public ActionResult Index3(Tbl_Member m)
        {
            var mail = (string)Session["Mail"];
            var update = db.Tbl_Member.FirstOrDefault(x => x.Mail == mail);

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string url = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/" + filename + url;
                Request.Files[0].SaveAs(Server.MapPath(path));
                m.Photo = "/Images/" + filename + url;
                update.Photo = m.Photo;
            }

            db.SaveChanges();
            return RedirectToAction("Logout");

        }
        public ActionResult BookList()
        {
            var value = (string)Session["Mail"];
            var find = db.Tbl_Member.FirstOrDefault(x => x.Mail == value);
            var book = db.Tbl_Process.Where(x => x.Member == find.MemberID).ToList();
            return View(book);
        }

        public PartialViewResult Announcement()
        {
            var list = db.Tbl_Announcement.ToList();
            return PartialView(list);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Log");
        }


        [HttpGet]
        public ActionResult SendMessage()
        {
            var mail = (string)Session["Mail"];
            var value = db.Tbl_Member.Where(x => x.Mail == mail).FirstOrDefault();
            ViewBag.mail = value.Mail;

            return View();

        }


        [HttpPost]
        public ActionResult SendMessage(Tbl_Contact m)
        {
            db.Tbl_Contact.Add(m);
            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Book()
        {
            var mail = (string)Session["Mail"];
            var find = db.Tbl_Process.Where(x => x.Tbl_Member.Mail == mail).ToList();

            return View(find);
        }

      


    }
}
