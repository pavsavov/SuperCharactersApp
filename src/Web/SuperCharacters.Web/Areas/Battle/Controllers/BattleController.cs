namespace SuperCharacters.Web.Areas.Battle.Controllers
{
    using Microsoft.AspNetCore.Mvc; 
    public class BattleController : Controller
    {
        [Area("Battle")]
        [Route("battle")]
        public IActionResult Index()
        {

            return View();
        }
    }
}