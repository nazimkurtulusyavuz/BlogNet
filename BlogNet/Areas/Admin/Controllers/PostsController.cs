using BlogNet.Controllers;
using BlogNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Areas.Admin.Controllers
{
    public class PostsController : AdminBaseController
    {
        private readonly ApplicationDbContext _db;

        public PostsController(ApplicationDbContext db)
        {
            _db = db;
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
            //todo : delete the post(with photo)
            return RedirectToAction("Index", new { message = "deleted" });
        }
    }
}
