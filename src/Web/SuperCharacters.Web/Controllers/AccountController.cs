using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperCharacters.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}