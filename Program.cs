using System;
using System.Linq;
using EFCore.Models;
using EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataContext();
            GetPosts(db);
            Console.Write("Do you want to add new blog post ? (Y/N) : ");
            string ans = Console.ReadLine();
            if (ans == "Y")
            {
                AddPost();
            }
        }

        private static void GetPosts(DataContext db)
        {
            var posts = db.Post.AsNoTracking();
            if (!posts.Any())
            {
                Console.WriteLine("**No blog posts found **");
                return;
            }

            foreach (var p in posts)
            {
                Console.WriteLine(p.ToString());
            }
        }
        private static void AddPost()
        {
            // Initialise the classes !
            var db = new DataContext();
            var newPost = new Blog();
            // Fill the data 
            var randId = new Random();
            newPost.Id = randId.Next();
            newPost.Title = Input("Enter the article title : ");
            newPost.Content = Input("Enter the article content : ");
            newPost.Category = Input("Category : ");
            newPost.Published = DateTime.Now;

            db.Add(newPost);
            db.SaveChanges();
        }

        private static string Input(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input;
        }
    }
}
