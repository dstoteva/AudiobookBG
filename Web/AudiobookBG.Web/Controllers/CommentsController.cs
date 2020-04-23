namespace AudiobookBG.Web.Controllers
{
    using System.Threading.Tasks;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(ICommentsService commentsService, UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateInputModel inputModel)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.commentsService.Create(inputModel.BookId, inputModel.Content, userId);

            return this.RedirectToAction("ById", "Books", new { id = inputModel.BookId });
        }
    }
}
