using SuperCharactersApp.ViewModels.DTO.TeamViewModels;

namespace SuperCharacters.Web.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services;
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;
    using System.Collections.Generic;
    using System.Linq;

    [Authorize]
    public class CharacterController : Controller
    {
        private readonly CharacterServices _characterServices;
        private readonly TeamServices _teamServices;
        public CharacterController(CharacterServices characterServices,
            TeamServices teamServices)
        {
            _teamServices = teamServices;
            _characterServices = characterServices;
        }

        public IActionResult ListCharacters()
        {
            var characters = _characterServices.GetAll();
           
            return this.View(characters);
        }

        public IActionResult Create()
        {
            var teams = _teamServices.GetAll().ToList();

            var createViewModel = new CharacterViewModel
            {

                Teams = teams
            };

            return View(createViewModel);
        }

        [HttpPost]
        public IActionResult Create(CharacterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Json(ModelState.ValidationState.ToString());
            }

            _characterServices.Create(viewModel);

            return this.RedirectToAction("ListCharacters");
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(CharacterViewModel viewModel)
        {
            return this.View();
        }
    }
}