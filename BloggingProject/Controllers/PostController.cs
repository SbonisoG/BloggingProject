using BloggingProject.Data;
using BloggingProject.Models.ViewsModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloggingProject.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string[] _allowedExtession = { ".jpg", ".jpeg", ".png" };
        public PostController(BlogDbContext context, IWebHostEnvironment webHostEnvironment) 
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                var inputFileExtension = Path.GetExtension(postViewModel.FeatureImage.FileName).ToLower();
                bool isAllowed = _allowedExtession.Contains(inputFileExtension);

                if (!isAllowed)
                {
                    ModelState.AddModelError("", "Invalid image format. Allowed format .jpd, .jpeg, .png.");
                    return View(postViewModel);
                }

               postViewModel.Post.imagePath = await UploadFiletoFolder(postViewModel.FeatureImage);
                await _context.Posts.AddAsync(postViewModel.Post);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(postViewModel );
        }

        private async Task<string> UploadFiletoFolder(IFormFile file)
        {
            var inputFileExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + inputFileExtension;
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var imageFolderPath = Path.Combine(wwwRootPath, "images");

            if(!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            var filePath = Path.Combine(imageFolderPath, fileName);

            try
            {
                await using(var fileStrem = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStrem);
                }
            }
            catch (Exception ex)
            {
                return "Error Uploadin Images:" + ex.Message;
            }

            return "/images/" + fileName;


        }
    }
}
