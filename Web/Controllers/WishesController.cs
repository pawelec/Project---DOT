using Core.Contexts;
using Core.Repositories;
using Domain.Interfaces;
using Domain.Models.Wishes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models.ViewModels.Wishes;

namespace Web.Controllers
{
    public class WishesController : Controller
    {
        protected readonly IWishesRepository _wishesRepository;
        protected readonly IUsersRepository _usersRepository;

        public WishesController()
        {
            var cxt = new Context();
            this._wishesRepository = new WishesRepository(cxt);
            this._usersRepository = new UsersRepository(cxt);
        }

        public ActionResult Index()
        {
            var wishes = this._wishesRepository.Get();
            var viewModels = AutoMapper.Mapper.Map<IEnumerable<WishViewModel>>(wishes);
            return View(viewModels);
        }

        public PartialViewResult GetNewestWishesPartial()
        {
            var newestWishes = AutoMapper.Mapper.Map<IEnumerable<WishViewModel>>(
                this._wishesRepository.Get().OrderByDescending(wish => wish.Created).Take(3));
            return PartialView("Partials/_NewestWishesPartial", newestWishes);
        }

        public ActionResult Details(int id)
        {
            var wish = this._wishesRepository.Get(id);
            var viewModel = AutoMapper.Mapper.Map<WishViewModel>(wish);
            ViewBag.IsWishObserved = Session["Observed"] != null ? 
                ((List<Wish>)Session["Observed"]).FirstOrDefault(w => w.Id == id) != null ? 
                    true : 
                    false : 
                false;
            return View(viewModel);
        }
        public ActionResult Create()
            => View();

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Content")] CreateWishViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Create");

            var domainWish = AutoMapper.Mapper.Map<Wish>(viewModel);
            domainWish.Creator = this._usersRepository.Get(this.User.Identity.Name);
            this._wishesRepository.Create(domainWish);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            this._wishesRepository.Delete(this._wishesRepository.Get(id));
            return RedirectToAction("Index");
        }
        public ActionResult Observe(int id)
        {
            var wish = this._wishesRepository.Get(id);
            if (wish == null)
                return RedirectToAction("Details", "Wishes", new { id = id });

            if (Session["Observed"] == null)
                Session["Observed"] = new List<Wish>();
            var observed = ((List<Wish>)Session["Observed"]);
               
            if (observed.FirstOrDefault(w => w.Id == wish.Id) != null)
                observed.Remove(observed.First(w => w.Id == wish.Id));
            else
                observed.Add(wish);

            return RedirectToAction("Details", "Wishes", new { id = id });
        }
    }
}