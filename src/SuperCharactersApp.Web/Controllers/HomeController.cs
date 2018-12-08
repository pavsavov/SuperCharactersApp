namespace SuperCharactersApp.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Web.Models;
    using SuperCharactersApp.Web.Data;
    public class HomeController : Controller
    {
        private readonly SuperCharactersAppDbContext context;

        public HomeController(SuperCharactersAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        { 

            return this.View();
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
