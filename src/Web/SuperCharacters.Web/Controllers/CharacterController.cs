namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services;
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using System.Collections.Generic;
    using System.Linq;

    [Authorize]
    public class CharacterController : Controller
    {
        private readonly CharacterServices _characterServices;
        private readonly TeamServices _teamServices;
        //private readonly SuperCharactersAppDbContext _dbcontext;
        public CharacterController(CharacterServices characterServices,
            TeamServices teamServices
            /*,SuperCharactersAppDbContext dbcontext*/)
        {
            //_dbcontext = dbcontext;
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
            //dummy

            var teams = _teamServices.GetAll().ToList();

            var characterViewModel = new CharacterViewModel
            {
                Teams = teams,
                SuperPowers = new List<CreateSuperPowerViewModel>()
                    {
                        new CreateSuperPowerViewModel { Name = "IronLady", Type = "Armour", Value = 22 },
                        new CreateSuperPowerViewModel { Name = "PowerfullSmite", Type = "Damage", Value = 133 },
                        new CreateSuperPowerViewModel { Name = "BringDeadPeopleAlive", Type = "Heal", Value = 3.3 }
                    },
            };

            //var secreteIdentity = new SecretIdentity { FirstName = "Ohlio", LastName = "Bohlio" };
            //var typeOfSuperPowers = (SuperPowerType)Enum.Parse(typeof(SuperPowerType), "Heal");
            //var createViewModel = new CharacterViewModel
            //{
            //    SuperPowers = new List<CreateSuperPowerViewModel>()
            //    {
            //        new CreateSuperPowerViewModel { Name = "IronLady", Type = "Armour", Value = 22 },
            //        new CreateSuperPowerViewModel { Name = "PowerfullSmite", Type = "Damage", Value = 133 },
            //        new CreateSuperPowerViewModel { Name = "BringDeadPeopleAlive", Type = "Heal", Value = 3.3 }
            //    },
            //    SecretIdentity = secreteIdentity,
            //    Teams = teams
            //};

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
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(CharacterViewModel viewModel)
        {
            return this.View();
        }
    }
}