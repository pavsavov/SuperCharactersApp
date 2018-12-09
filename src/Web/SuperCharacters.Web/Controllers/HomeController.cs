using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperCharacters.Web.Models;
using Microsoft.Extensions.DependencyInjection;
using SuperCharacters.Web.Data;
using SuperCharacters.Models;

namespace SuperCharacters.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider provider;
        public HomeController(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public IActionResult Index()
        {
            //Test
            var dbcontext = provider.GetRequiredService<SuperCharactersDbContext>();

 
            dbcontext.Add(new SuperHero { Name = "Sashko", HitPoints = 133, Armour = 33, Damage = 33, Team= new Team { Name= "asdada"} });
            dbcontext.SaveChanges();
            return this.View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
