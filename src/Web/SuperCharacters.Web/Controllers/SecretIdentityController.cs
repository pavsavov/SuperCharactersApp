namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels;
    /// <summary>
    /// Controller responsible for CRUD operation on Secretidentity Entity.
    /// </summary>

    [Authorize]
    public class SecretIdentityController : Controller
    {
        private readonly IService<SecretIdentityViewModel> _secretIdentityServices;

        public SecretIdentityController(IService<SecretIdentityViewModel> secretIdentityServices)
        {
            _secretIdentityServices = secretIdentityServices;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crete(SecretIdentityViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _secretIdentityServices.Create(viewModel);

            return RedirectToAction("Home","Index");

        }
    }
}