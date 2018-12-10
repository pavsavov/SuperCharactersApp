namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;

    [Authorize]
    public class TeamController : Controller
    {
        private readonly TeamServices _teamServices;
        public TeamController(TeamServices teamServices)
        {
            _teamServices = teamServices;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTeamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Json("Invalid team name");
            }

            _teamServices.Create(viewModel);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult ListTeams()
        {
            var allTeams = _teamServices.GetAll();

            return this.View(allTeams);
        }
    }
}