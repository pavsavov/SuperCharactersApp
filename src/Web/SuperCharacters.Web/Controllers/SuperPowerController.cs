namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;

    [Authorize]
    public class SuperpowerController : Controller
    {
        private readonly SuperpowerServices _superpowerServices;

        public SuperpowerController(SuperpowerServices superpowerServices)
        {
            _superpowerServices = superpowerServices;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SuperPowersListingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _superpowerServices.Create(viewModel);

            }

            return RedirectToAction("ListSuperpowers", "SuperPower");
        }

        public IActionResult ListSuperpowers()
        {

            var superpowers = _superpowerServices.GetAll();

            return View(superpowers);
        }
    }
}