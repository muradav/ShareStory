using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareStory.DAL;
using ShareStory.Models;
using ShareStory.ViewModels;
using System.Security.Claims;

namespace ShareStory.Controllers
{
    public class StoryController : Controller
    {
        private readonly AppDbContext _context;

        public StoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Share(HomeVM homeVM)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (userId == null) return View("Please login first");

            Story newStory = new Story();

            newStory.AuthorId = userId;
            newStory.Topic = homeVM.Story.Topic;
            newStory.LikeCount = homeVM.Story.LikeCount;
            newStory.isDeleted = homeVM.Story.isDeleted;

            await _context.AddAsync(newStory);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> LikeAction(int id)
        {
            Story story = await _context.Stories.Include(s => s.Likes).FirstOrDefaultAsync(s => s.Id == id);
            if (User.Identity.IsAuthenticated)
            {
                var Username = User.Identity.Name;
                User user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == Username);

                if (story.Likes.Any(u => u.LikedUserId == user.Id)) return BadRequest();
                
                story.LikeCount++;
                Like like = new Like();
                like.LikedStoryId = id;
                like.LikedUserId = user.Id;
                like.LikedDate = DateTime.Now;
                like.Liked = true;
                _context.Likes.Add(like);
                await _context.SaveChangesAsync();
            }

            return Ok(story);
        }

        public async Task<IActionResult> UnlikeAction(int id)
        {
            Story story = await _context.Stories.Include(s => s.Likes).FirstOrDefaultAsync(s => s.Id == id);
            if (User.Identity.IsAuthenticated)
            {
                var Username = User.Identity.Name;
                User user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == Username);

                //if (story.Likes.Any(u => u.LikedUserId != user.Id)) return BadRequest();

                Like like = await _context.Likes.FirstOrDefaultAsync(l => l.LikedStoryId == id && l.LikedUserId == user.Id);
                story.LikeCount--;
                _context.Remove(like);
                await _context.SaveChangesAsync();

            }
            return Ok(story);
        }
    }
}
