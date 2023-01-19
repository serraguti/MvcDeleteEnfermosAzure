using Microsoft.AspNetCore.Mvc;
using MvcDeleteEnfermosAzure.Models;
using MvcDeleteEnfermosAzure.Repositories;

namespace MvcDeleteEnfermosAzure.Controllers
{
    public class EnfermosController : Controller
    {
        RepositoryEnfermos repo;

        public EnfermosController(RepositoryEnfermos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }

        [HttpPost]
        public IActionResult Index(int inscripcion)
        {
            this.repo.DeleteEnfermo(inscripcion);
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }
    }
}
