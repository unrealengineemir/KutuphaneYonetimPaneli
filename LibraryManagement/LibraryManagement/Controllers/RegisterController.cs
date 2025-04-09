using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;
using LibraryManagement.Repository;

namespace LibraryManagement.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register

        MemberRepository repo = new MemberRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Member m)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string url = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/İmages/" + filename + url;
                Request.Files[0].SaveAs(Server.MapPath(path));
                m.Photo = "/İmages/" + filename + url;

            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            m.Authority = "B";
            repo.TAdd(m);
            return RedirectToAction("Index");

        }



    }
}