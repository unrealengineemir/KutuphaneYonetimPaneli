using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Repository;
using PagedList;
using PagedList.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "A")]
    public class HistoryController : Controller
    {
        // GET: History
        ProcessRepository repo = new ProcessRepository();

        public ActionResult Index(int page = 1)
        {
            var list = repo.List().ToPagedList(page, 10);
            return View(list);
        }
    }
}