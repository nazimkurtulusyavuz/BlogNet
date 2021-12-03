using BlogNet.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Areas.Admin.Models
{
    public class EditPostViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Content { get; set; }

        public bool IsPublished { get; set; } = true;
        
        [PostPhoto(MaxSizeMB = 1)]  // Buraya yazılan MaxSizeMB PostPhotoAttribute'dakini ezer.
        public IFormFile FeaturedImage { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
