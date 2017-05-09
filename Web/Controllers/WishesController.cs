using Core.Repositories;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models.ViewModels.Wishes;

namespace Web.Controllers
{
    public class WishesController : Controller
    {
        protected readonly IWishesRepository _wishesRepository;

        public WishesController()
        {
            this._wishesRepository = new WishesRepository();
        }

        [AllowAnonymous]
        public PartialViewResult GetNewestWishesPartial()
        {
            var newestWishes = AutoMapper.Mapper.Map<IEnumerable<WishViewModel>>(
                this._wishesRepository.Get().OrderByDescending(wish => wish.Created).Take(3));
            return PartialView("Partials/_NewestWishesPartial", newestWishes);
        }
    }
}