using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS4439_CA2.Data;
using IS4439_CA2.Models;

namespace IS4439_CA2.Controllers
{
    public class ProjectImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectImages
        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = _context.ProjectImages.Include(p => p.Project).Where(p => p.ProjectId == id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectImages = await _context.ProjectImages
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectImagesID == id);
            if (projectImages == null)
            {
                return NotFound();
            }

            return View(projectImages);
        }

        // GET: ProjectImages/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "DateCompleted");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectImagesID,imageRoute,ProjectId")] ProjectImages projectImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectImages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "DateCompleted", projectImages.ProjectId);
            return View(projectImages);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectImages = await _context.ProjectImages.FindAsync(id);
            if (projectImages == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "DateCompleted", projectImages.ProjectId);
            return View(projectImages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectImagesID,imageRoute,ProjectId")] ProjectImages projectImages)
        {
            if (id != projectImages.ProjectImagesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectImagesExists(projectImages.ProjectImagesID))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "DateCompleted", projectImages.ProjectId);
            return View(projectImages);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectImages = await _context.ProjectImages
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectImagesID == id);
            if (projectImages == null)
            {
                return NotFound();
            }

            return View(projectImages);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectImages = await _context.ProjectImages.FindAsync(id);
            _context.ProjectImages.Remove(projectImages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectImagesExists(int id)
        {
            return _context.ProjectImages.Any(e => e.ProjectImagesID == id);
        }
    }
}
