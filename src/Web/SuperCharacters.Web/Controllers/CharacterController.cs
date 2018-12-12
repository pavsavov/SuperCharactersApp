namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;
    using System;
    using System.Linq;

    [Authorize]
    public class CharacterController : Controller
    {
        private readonly CharacterServices _characterServices;
        private readonly TeamServices _teamServices;
        private readonly SuperpowerServices _superPowerServices;

        public CharacterController(CharacterServices characterServices,
            TeamServices teamServices,
            SuperpowerServices superPowerServices)
        {
            _superPowerServices = superPowerServices;
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

            var superpowers = _superPowerServices.GetAll().ToList();

            var characterViewModel = new CharacterViewModel
            {
                Teams = teams,
                SuperPowers = superpowers
            };
            
            return View(characterViewModel);
        }

        [HttpPost]
        public IActionResult Create(CharacterCreateViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return this.Json(ModelState.ValidationState.ToString());
            //}

            _characterServices.Create(viewModel);

            return this.RedirectToAction("ListCharacters");
        }

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit(string viewModel)
        {
            throw new NotImplementedException();

        }

        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            throw new NotImplementedException();

        }
    }
}