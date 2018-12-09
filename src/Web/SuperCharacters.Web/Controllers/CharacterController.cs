using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;

namespace SuperCharacters.Web.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        public IActionResult ListCharacters()
        {
            var dummy = new List<CharacterViewModel>
            {
                new CharacterViewModel{Armour=33,Damage=33,HitPoints=122,CharacterType= "SuperHero",Name = "Sashko Bombeto",Team="Izorid"},
                new CharacterViewModel{Armour=33,Damage=33,HitPoints=122,CharacterType= "SuperHero",Name = "Sashko Shisheto",Team="Izorid"},
                new CharacterViewModel{Armour=33,Damage=33,HitPoints=122,CharacterType= "SuperHero",Name = "Sashko Alkoholika",Team="Izorid"},

            };

            return this.View(dummy);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CharacterViewModel viewModel)
        {
            return this.View();
        }
    }
}