namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    /// <summary>
    /// Controller responsible for CRUD operation on Character Entity.
    /// </summary>

    [Authorize]
    public class CharacterController : Controller
    {
        private readonly CharacterServices _characterServices;
        private readonly TeamServices _teamServices;
        private readonly SuperpowerServices _superPowerServices;

        public CharacterController(
            CharacterServices characterServices,
            TeamServices teamServices,
            SuperpowerServices superPowerServices)
        {
            _superPowerServices = superPowerServices;
            _teamServices = teamServices;
            _characterServices = characterServices;
        }

        [HttpGet]
        public IActionResult ListCharacters()
        {
            var characters = _characterServices.GetAll();

            return this.View(characters);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var characterViewModel = new CharacterCreateViewModel
            {
                Teams = LoadTeams(),
                SuperPowers = LoadSuperPowers()
            };

            return View(characterViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CharacterCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Teams = LoadTeams();
                viewModel.SuperPowers = LoadSuperPowers();
                return View("Create", viewModel);
            }

            _characterServices.Create(viewModel);

            return RedirectToAction("ListCharacters");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string viewModel)
        {
            throw new NotImplementedException();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string formModal)
        {
            var id = formModal;

            var character = _characterServices.GetById(id);

            if (character != null)
            {
                _characterServices.DeleteById(id);

                var currentCharacters = _characterServices.GetAll();
                return RedirectToAction("ListCharacters", currentCharacters);
            }
            else
            {
                return Json("Invalid Id.Try again");
            }
        }

        #region loadAdditionalDataMethods

        private ICollection<CreateTeamViewModel> LoadTeams()
        {
            return _teamServices.GetAll().ToList();
        }

        private ICollection<SuperPowersListingViewModel> LoadSuperPowers()
        {
            return _superPowerServices.GetAll().ToList();
        }
        #endregion
    }
}
