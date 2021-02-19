using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenshinDB.Data;
using GenshinDB.Models;

namespace GenshinDB.Controllers
{
    public class ArtifactsController : Controller
    {
        private readonly GenshinDBContext _context;

        public ArtifactsController(GenshinDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Artifacts
        public async Task<IActionResult> Index(string searchString)
        {
             var artifacts = from m in _context.Artifact
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

            var artifact = await _context.Artifact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artifact == null)
            {
                return NotFound();
            }

            return View(artifact);
        }

        // GET: Artifacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artifacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rarity,SetEffect2,SetEffect4,Description,FullDescription")] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artifact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artifact);
        }

        // GET: Artifacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = await _context.Artifact.FindAsync(id);
            if (artifact == null)
            {
                return NotFound();
            }
            return View(artifact);
        }

        // POST: Artifacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rarity,SetEffect2,SetEffect4,Description,FullDescription")] Artifact artifact)
        {
            if (id != artifact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artifact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtifactExists(artifact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(artifact);
        }

        // GET: Artifacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = await _context.Artifact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artifact == null)
            {
                return NotFound();
            }

            return View(artifact);
        }

        // POST: Artifacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artifact = await _context.Artifact.FindAsync(id);
            _context.Artifact.Remove(artifact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtifactExists(int id)
        {
            return _context.Artifact.Any(e => e.Id == id);
        }
    }
}
