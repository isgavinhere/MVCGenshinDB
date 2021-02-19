using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GenshinDB.Models;
using GenshinDB.Data;
using Microsoft.EntityFrameworkCore;

namespace GenshinDB.Controllers
{
    public class HomeController : Controller
    {
/*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
*/
        private readonly GenshinDBContext _contextHome;

        public HomeController(GenshinDBContext context)
        {
            _contextHome = context;
        }

        private bool ArtifactExists(int id)
        {
            return _contextHome.Artifact.Any(e => e.Id == id);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Artifacts
        public async Task<IActionResult> Index(string searchString)
        {
             var artifacts = from m in _contextHome.Artifact
                 select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                artifacts = artifacts.Where(s => s.Name.Contains(searchString));
            }

            return View(await artifacts.ToListAsync());
        }

        // GET: Artifacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = await _contextHome.Artifact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artifact == null)
            {
                return NotFound();
            }

            return View(artifact);
        }
/*
        public IActionResult Index()
        {
            return View();
        }
*/
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
