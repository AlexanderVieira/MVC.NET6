using AVS.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AVS.MVC.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace AVS.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Coordenador")]
        public IActionResult Recurso()
        {
            return View("Recurso");
        }

        [Authorize(Policy = "Excluir")]
        public IActionResult RecursoClaim()
        {
            return View("Recurso");
        }

        [Authorize(Policy = "Editar")]
        public IActionResult RecursoClaimRequeriment()
        {
            return View("Recurso");
        }

        [ClaimAuthorize("Produtos", "Ler")]
        public IActionResult RecursoClaimCustom()
        {
            return View("Recurso");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}