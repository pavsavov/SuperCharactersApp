namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;
    using SuperCharactersApp.ViewModels.DTO.ReusableModalModel;
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
        [ValidateAntiForgeryToken]
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
    }
}