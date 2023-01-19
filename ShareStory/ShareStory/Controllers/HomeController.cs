using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareStory.DAL;
using ShareStory.Helpers;
using ShareStory.Models;
using ShareStory.ViewModels;
using System.Security.Claims;

namespace ShareStory.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 2)
        {
            HomeVM home = new HomeVM();

            home.Stories = await _context.Stories
                .Where(s => s.isDeleted == false)
                .Include(s => s.Author)
                .Include(s => s.Comments)
                .Include(s => s.Likes)
                .OrderByDescending(s => s.Id)
                .ToListAsync();
            home.PagedLists = PagedList<Story>.CreateAsync(home.Stories, page, pageSize);

            return View(home);
        }
    }
}
