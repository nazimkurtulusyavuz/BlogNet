using BlogNet.Areas.Admin.Models;
using BlogNet.Controllers;
using BlogNet.Data;
using BlogNet.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Areas.Admin.Controllers
{
    public class PostsController : AdminBaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly UrlService _urlService;

        public PostsController(ApplicationDbContext db, IWebHostEnvironment env, UrlService urlService)
        {
            _db = db;
            _env = env;
            _urlService = urlService;
        }
        public IActionResult Index()
        {
            return View(_db.Posts
                .Include(p => p.Category)
                .Include(p => p.Author)
                .ToList());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var post = _db.Posts.Find(id);
            if (post == null) return NotFound();
            DeletePhoto(post.PhotoPath);
            _db.Posts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("Index", new { message = "deleted" });
        }

        private void DeletePhoto(string photoPath)
        {
            if (string.IsNullOrEmpty(photoPath)) return;
            try
            {
                var deletePath = Path.Combine(_env.WebRootPath, "uploads", photoPath);
                System.IO.File.Delete("");
            }
            catch (Exception) { }
        }

        public IActionResult New()
        {
            var vm = new NewPostViewModel()
            {
                Categories = _db.Categories.OrderBy(c => c.Name).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList()
            };
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult New(NewPostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //Save
            }
            vm.Categories = _db.Categories
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                .ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult GenerateSlug(string text)
        {
            string slug = _urlService.URLFriendly(text);
            return Content(slug);
        }
    }
}
