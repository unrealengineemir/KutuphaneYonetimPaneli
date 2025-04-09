using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Controllers
{
   
    public class ContactController : Controller
    {
        // GET: Contact
        LibraryDBEntities1 db = new LibraryDBEntities1();


        public ActionResult Index()
        {
            var find = (string)Session["Mail"];
            var values = db.Tbl_Contact.Where(x => x.Buyer == find).ToList();
    
            return View(values);
        }

        public ActionResult OutGoing()
        {
            var find = (string)Session["Mail"];
            var value = db.Tbl_Contact.Where(x => x.Sender == find).ToList();

            return View(value);
        }

        public ActionResult NewMessage(Tbl_Contact m)
        {
            db.Tbl_Contact.Add(m);
            db.SaveChanges();
            return View();
        }

        public ActionResult Partial()
        {
            var mail = (string)Session["Mail"];
            var buyer = db.Tbl_Contact.Where(x => x.Buyer == mail).Count();
            var sender = db.Tbl_Contact.Where(x => x.Sender == mail).Count();
            ViewBag.dgr = buyer;
            ViewBag.dgr2 = sender;

            return PartialView();
        }


    }
}