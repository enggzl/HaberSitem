using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HaberSitem.Web.Models;
using HaberSitem.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace HaberSitem.Web.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var news = context.News.Include(i => i.Category).Where(n =>n.IsPublished==true).OrderByDescending(o => o.PublishDate).Take(10).ToList();
            var categories = context.Categories.OrderBy(c => c.Name).Select(s => new CategoryViewModel { Id = s.Id, Name = s.Name, Count = s.News.Count }).ToList();
            ViewBag.Categories = categories;
            var vm = new CommentsViewModel();
            vm.News = news;
            vm.Comments = context.Comments.Take(10).ToList();
            return View(vm); 
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
