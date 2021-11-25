using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedRolesAndUsers(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await roleManager.CreateAsync(new IdentityRole("admin"));
            var user = new ApplicationUser()
            {
                Email = "admin@example.com",
                UserName = "admin@example.com",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(user, "P@ssword1");
            await userManager.AddToRoleAsync(user, "admin");
        }
        public static async Task SeedCategoriesAndPostsAsync(ApplicationDbContext context)
        {
            var author = await context.Users.FirstOrDefaultAsync(x => x.UserName == "admin@example.com");
            if (author == null || await context.Categories.AnyAsync()) return;
            {

            }
            var cat1 = new Category()
            {
                Name = "General",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Title = "Welcome to My Blog",
                        Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                        PhotoPath = "sample-photo-1.jpg",
                        Slug = "welcome-to-my-blog",
                        Author = author,
                    },

                    new Post()
                    {
                        Title = "A Sunny Day",
                        Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                        PhotoPath = "sample-photo-2.jpg",
                        Slug = "a-sunny-day",
                        Author = author,
                    }
                },
            };

           
            context.Categories.AddRange(cat1);
            await context.SaveChangesAsync();

        }
    }
}
