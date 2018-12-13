namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels;

    [Authorize]
    public class SecretIdentityController : Controller
    {
        private readonly IService<SecretIdentityViewModel> _secretIdentityServices;

        public SecretIdentityController(IService<SecretIdentityViewModel> secretIdentityServices)
        {
            _secretIdentityServices = secretIdentityServices;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crete(SecretIdentityViewModel viewModel)
        {
            _secretIdentityServices.Create(viewModel);

            return View(viewModel);

        }
    }
}