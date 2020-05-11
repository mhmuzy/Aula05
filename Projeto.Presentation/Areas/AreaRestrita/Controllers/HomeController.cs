using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Projeto.Presentation.Controlers
{
    [Area("AreaRestrita")]
    public class HomeController : Controller
    {
        //IActionResult -> métodos que realizam ações em páginas

        public IActionResult Index()
        {
            return View();
        }
    }
}