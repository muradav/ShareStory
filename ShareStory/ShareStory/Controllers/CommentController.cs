using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareStory.DAL;
using ShareStory.Models;
using ShareStory.ViewModels;

namespace ShareStory.Controllers
{
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendComment(int storyId, HomeVM homeVM)
        {
            Story story = await _context.Stories.FirstOrDefaultAsync(x => x.Id == storyId);

            if (story == null) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
                var Username = User.Identity.Name;

                User user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == Username);

                Comment newComment = new Comment();

                newComment.Content = homeVM.Comment.Content;
                newComment.UserId = user.Id;
                newComment.StoryId = story.Id;
                newComment.isDeleted = false;

                await _context.AddAsync(newComment);
                await _context.SaveChangesAsync();

            }

            return Ok(story);
        }

        //[HttpPost]
        //public async Task<IActionResult> SendComment(int storyId, string content)
        //{
        //    Story story = await _context.Stories.FirstOrDefaultAsync(x => x.Id == storyId);

        //    if (story == null) return NotFound();

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var Username = User.Identity.Name;

        //        User user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == Username);

        //        Comment newComment = new Comment();

        //        newComment.Content = content;
        //        newComment.UserId = user.Id;
        //        newComment.StoryId = story.Id;
        //        newComment.isDeleted = false;

        //        await _context.AddAsync(newComment);
        //        await _context.SaveChangesAsync();

        //    }

        //    return Ok(story);
        //}
    }
}
