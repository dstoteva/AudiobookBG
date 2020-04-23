namespace AudiobookBG.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AudiobookBG.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : AdministrationController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bookId = await this.commentsService.Delete(id);

            return this.RedirectToAction("ById", "Books", new { id = bookId, Area = "" });
        }
    }
}
