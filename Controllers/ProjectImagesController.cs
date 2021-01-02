using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS4439_CA2.Data;
using IS4439_CA2.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IS4439_CA2.Controllers
{
    [Authorize]
    public class ProjectImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _User;
        public ProjectImagesController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _User = user;

        }
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _User.GetUserAsync(HttpContext.User);
        }

        // GET: ProjectImages
        public async Task<IActionResult> Index(int id)
        {
            ApplicationUser user = await GetCurrentUser();
            if(user == null || !user.IsAdmin)
            {
                return Redirect("/");
            }
            var applicationDbContext = _context.ProjectImages.Include(p => p.Project).Where(p => p.ProjectId == id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ApplicationUser user = await GetCurrentUser();
            if (user == null || !user.IsAdmin)
            {
                return Redirect("/");
            }

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
        public IActionResult Create(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            ViewData["ProjectId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFileCollection formFiles, int ProjectId)
        {
            ApplicationUser user = await GetCurrentUser();
            if (user == null || !user.IsAdmin)
            {
                return Redirect("/");
            }

            if (formFiles.Count == 0)
            {
                TempData["Error"] = "Please upload at least one image!";
                return View();
            }
            Projects project = await _context.Projects.FindAsync(ProjectId);
            string Dir = project.Dir;
            List<ProjectImages> pi = new List<ProjectImages>();
            foreach (IFormFile image in formFiles)
            {
                string imageName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                string myUniqueImageName = Convert.ToString(Guid.NewGuid());
                string FileExtension = Path.GetExtension(imageName);
                string fullImageID = myUniqueImageName + FileExtension;
                
                string dir = $"wwwroot{Dir}/{fullImageID}";
                string path = $"~{Dir}/{fullImageID}";

                if (!Directory.Exists($"wwwroot{Dir}"))
                {

                    TempData["Error"] = "Unable to add image, Please try again later";
                    return View();

                }
                using (FileStream fs = System.IO.File.Create(dir))
                {
                    image.CopyTo(fs);
                    fs.Flush();
                }
                pi.Add(new ProjectImages() { imageRoute = path });
            }

            foreach(ProjectImages p in pi)
            {
                p.ProjectId = ProjectId;
                if (ModelState.IsValid)
                {
                    _context.Add(p);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index), new {id = ProjectId } );
        }

        public async Task<IActionResult> Delete(int? id)
        {
            ApplicationUser user = await GetCurrentUser();
            if (user == null || !user.IsAdmin)
            {
                return Redirect("/");
            }

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
            ApplicationUser user = await GetCurrentUser();
            if (user == null || !user.IsAdmin)
            {
                return Redirect("/");
            }

            var projectImages = await _context.ProjectImages.FindAsync(id);
            int projectID = projectImages.ProjectId;
            _context.ProjectImages.Remove(projectImages);
            await _context.SaveChangesAsync();
            bool isEmpty = await IsProjectEmpty(projectID);
            if (isEmpty)
            {
                return Redirect("/");
            }
            return Redirect("/");
        }

        public async Task<bool> IsProjectEmpty(int id)
        {
            var list = _context.ProjectImages.Where(p => p.ProjectId == id).ToList();

            if(!(list.Count > 0))
            {
                var project = await _context.Projects.FindAsync(id);
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
         
        }
    }

}
