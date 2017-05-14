using Core.Repositories;
using Domain.Interfaces;
using Domain.Models.Comments;
using System.Web.Mvc;
using Web.Models.ViewModels.Comments;

namespace Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IWishesRepository _wishesRepository;

        public CommentsController()
        {
            var cxt = new Core.Contexts.Context();
            this._commentsRepository = new CommentsRepository(cxt);
            this._wishesRepository = new WishesRepository(cxt);
        }

        [HttpPost, /*ValidateAntiForgeryToken*/]
        public ActionResult Create(/*[Bind(Include = "Content")] */CreateCommentViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Details", "Wish", new { Id = viewModel.WishId });

            var domainComment = AutoMapper.Mapper.Map<Comment>(viewModel);
            domainComment.Wish = this._wishesRepository.Get(viewModel.WishId);
            this._commentsRepository.Create(domainComment);

            return RedirectToAction("Index");
        }
    }
}