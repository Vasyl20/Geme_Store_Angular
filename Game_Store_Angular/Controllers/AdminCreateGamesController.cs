using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.Controllers
{
    [Route("api/AdminCreateGames")]
    [ApiController]
    public class AdminCreateGamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
