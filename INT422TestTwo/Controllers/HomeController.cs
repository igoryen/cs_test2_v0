using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestTwo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movies()
        {
            return RedirectToAction("Index","Movie");
        }

        public ActionResult Directors()
        {
            return RedirectToAction("Index","Director");
        }

        public ActionResult Genres()
        {
            return RedirectToAction("Index","Genre");
        }
    }
}