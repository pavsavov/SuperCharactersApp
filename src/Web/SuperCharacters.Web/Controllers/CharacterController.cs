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
    /// Controller responsible for Characters Entity.
    /// </summary>
    [Authorize]
    public class CharacterController : Controller
    {
        private readonly CharacterServices _characterServices;
        private readonly TeamServices _teamServices;
        private readonly SuperpowerServices _superPowerServices;
        private readonly PaginationServices<CharacterViewModel> _paginationServices;

        public CharacterController(
            CharacterServices characterServices,
            TeamServices teamServices,
            SuperpowerServices superPowerServices,
            PaginationServices<CharacterViewModel> paginationServices
            )
        {
            _paginationServices = paginationServices;
            _superPowerServices = superPowerServices;
            _teamServices = teamServices;
            _characterServices = characterServices;
        }

        [HttpGet]
        public IActionResult ListCharacters(int? pageNumber)
        {
            var paginatedCharactersList = _paginationServices.Pagination(pageNumber, _characterServices);

            return View(paginatedCharactersList);

        }

        [HttpGet]
        public IActionResult Create()
        {
            var characterViewModel = new CharacterViewModel
            {
                Teams = LoadTeams(),
                SuperPowers = LoadSuperPowers()
            };

            return View(characterViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CharacterViewModel viewModel)
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
        public IActionResult Details(string id)
        {



            return PartialView("Partials/_DetailsCharacter");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CharacterViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _characterServices.Edit(editModel);

            return RedirectToAction("ListCharacters", "Character");

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

                var currentCharactersList = _characterServices.GetAll();
                return RedirectToAction("ListCharacters", currentCharactersList);
            }
            else
            {
                return Json("Invalid Id.Try again");
            }
        }

        #region AdditionalControllerLoadPartialName
        public IActionResult LoadPartialView()
        {
            var superpowers = _superPowerServices.GetAll();

            return PartialView("Partials/_EditCharacterSuperPowers",superpowers);
        }
        #endregion

        #region LoadAdditionalData

        private ICollection<TeamViewModel> LoadTeams()
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
