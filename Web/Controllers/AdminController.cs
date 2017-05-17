using Core.Contexts;
using Core.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IWishesRepository _wishesRepository;
        private readonly ICommentsRepository _commentsRepository;

        public AdminController()
        {
            var cxt = new Context();
            this._wishesRepository = new WishesRepository(cxt);
            this._commentsRepository = new CommentsRepository(cxt);
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Wishes = this._wishesRepository.Get().Count;
            ViewBag.Comments = this._commentsRepository.Get().Count;
            return View();
        }
    }
}