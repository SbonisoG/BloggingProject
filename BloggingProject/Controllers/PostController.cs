using BloggingProject.Data;
using BloggingProject.Models.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloggingProject.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext _context;
        public PostController(BlogDbContext context) 
        {
            _context = context;
        }
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Post";

            var postViewModel = new PostViewModel();
            postViewModel.Categories = _context.Categories.Select(c =>
            new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            }
            ).ToList();

            return View(postViewModel);
        }
    }
}
