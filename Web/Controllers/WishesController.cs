﻿using Core.Repositories;
using Domain.Interfaces;
using Domain.Models.Wishes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models.ViewModels.Wishes;

namespace Web.Controllers
{
    [Authorize]
    public class WishesController : Controller
    {
        protected readonly IWishesRepository _wishesRepository;
        protected readonly IUsersRepository _usersRepository;

        public WishesController()
        {
            this._wishesRepository = new WishesRepository();
            this._usersRepository = new UsersRepository();
        }

        [AllowAnonymous]
        public PartialViewResult GetNewestWishesPartial()
        {
            var newestWishes = AutoMapper.Mapper.Map<IEnumerable<WishViewModel>>(
                this._wishesRepository.Get().OrderByDescending(wish => wish.Created).Take(3));
            return PartialView("Partials/_NewestWishesPartial", newestWishes);
        }

        public ActionResult Create()
            => View();

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Content")] CreateWishViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Create");

            var domainWish = AutoMapper.Mapper.Map<Wish>(viewModel);
            domainWish.Creator = this._usersRepository.Get(this.User.Identity.Name);
            this._wishesRepository.Create(domainWish);

            return RedirectToAction("Index", "Home");
        }
    }
}