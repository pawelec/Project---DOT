using Domain.Models.Wishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Observed = (List<Wish>)Session["Observed"] ?? new List<Wish>();
            return View();
        }
    }
}