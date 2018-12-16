namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
    /// <summary>
    /// Controller responsible for CRUD operation on Team Entity.
    /// </summary>
    /// 
    [Authorize]
    public class TeamController : Controller
    {
        private readonly TeamServices _teamServices;
        public TeamController(TeamServices teamServices)
        {
            _teamServices = teamServices;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(CreateTeamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

             _teamServices.Create(viewModel);

            return this.RedirectToAction("Create", "Character");
        }

        [HttpGet]
        public IActionResult ListTeams()
        {
            var allTeams = _teamServices.GetAll();

            return this.View(allTeams);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string formModal)
        {
            var id = formModal;

            var superpower = _teamServices.GetById(id);

            if (superpower != null)
            {
                _teamServices.DeleteById(id);

                var currentTeamList = _teamServices.GetAll();
                return RedirectToAction("ListTeams", currentTeamList);
            }
            else
            {
                return Json("Invalid Id.Try again");
            }
        }
    }
}