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
    public class ProjectCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectComments.Include(p => p.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectComments = await _context.ProjectComments
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectCommentsID == id);
            if (projectComments == null)
            {
                return NotFound();
            }

            return View(projectComments);
        }

        // GET: ProjectComments/Create

        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "ProjectsID");
            return View();
        }

        // POST: ProjectComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectCommentsID,CommentText,CommentTimeStamp,ProjectId")] ProjectComments projectComments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "ProjectsID", projectComments.ProjectId);
            return View(projectComments);
        }

        // GET: ProjectComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectComments = await _context.ProjectComments.FindAsync(id);
            if (projectComments == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "ProjectsID", projectComments.ProjectId);
            return View(projectComments);
        }

        // POST: ProjectComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectCommentsID,CommentText,CommentTimeStamp,ProjectId")] ProjectComments projectComments)
        {
            if (id != projectComments.ProjectCommentsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectCommentsExists(projectComments.ProjectCommentsID))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "ProjectsID", projectComments.ProjectId);
            return View(projectComments);
        }

        // GET: ProjectComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectComments = await _context.ProjectComments
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectCommentsID == id);
            if (projectComments == null)
            {
                return NotFound();
            }

            return View(projectComments);
        }

        // POST: ProjectComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectComments = await _context.ProjectComments.FindAsync(id);
            _context.ProjectComments.Remove(projectComments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectCommentsExists(int id)
        {
            return _context.ProjectComments.Any(e => e.ProjectCommentsID == id);
        }
    }
}
