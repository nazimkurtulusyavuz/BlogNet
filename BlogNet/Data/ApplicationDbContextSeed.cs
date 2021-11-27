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
            
            var cat1 = new Category()
            {
                Name = "General",
                Slug = "general",
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

            var cat2 = new Category()
            {
                Name = "Life Style",
                Slug = "life-style",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Title = "Remote Work",
                        Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                        PhotoPath = "sample-photo-3.jpg",
                        Slug = "remote-work",
                        Author = author,
                    },

                    new Post()
                    {
                        Title = "Finding Peace in Nature",
                        Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                        PhotoPath = "sample-photo-4.jpg",
                        Slug = "finding-peace-in-nature",
                        Author = author,
                    }
                },
            };

            var cat3 = new Category()
            {
                Name = "Travel",
                Slug = "travel",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Title = "Getting Away From The City",
                        Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                        PhotoPath = "sample-photo-5.jpg",
                        Slug = "getting-away-from-the-city",
                        Author = author,
                    },

                    new Post()
                    {
                        Title = "My Summer House",
                        Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                        PhotoPath = "sample-photo-6.jpg",
                        Slug = "my-summer-house",
                        Author = author,
                    }
                },
            };

            var cat4 = new Category()
            {
                Name = "Nature",
                Slug = "nature",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Title = "A Green Life",
                        Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                        PhotoPath = "sample-photo-7.jpg",
                        Slug = "a-green-life",
                        Author = author,
                    },

                    new Post()
                    {
                        Title = "Welcome Autumn",
                        Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                        PhotoPath = "sample-photo-8.jpg",
                        Slug = "welcome-autumn",
                        Author = author,
                    }
                },
            };


            context.Categories.AddRange(cat1 ,cat2, cat3, cat4);
            await context.SaveChangesAsync();

        }
    }
}
