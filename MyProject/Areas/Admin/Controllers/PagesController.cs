using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Service.Services;
using Service.Interfaces;

namespace MyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private IPageService _pageService;
        private IPageGroupService _pageGroupService;
        private readonly ParsaDbContext _context = new ParsaDbContext();

        public PagesController()
        {
            _pageService = new PageService(_context);
            _pageGroupService = new PageGroupService(_context);
        }

        // GET: Admin/Pages
        public async Task<IActionResult> Index()
        {
            var parsaDbContext = _context.Pages.Include(p => p.PageGroup);
            return View(await parsaDbContext.ToListAsync());
        }

        // GET: Admin/Pages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .Include(p => p.PageGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Admin/Pages/Create
        public IActionResult Create()
        {
            ViewData["PageGroupId"] = new SelectList(_pageGroupService.GetAllGroups(), "Id", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PageGroupId,Title,ShortDiscription,Text,Visit,ImageName,ShowInSlider,CreateDate")] Page page)
        {

            page.Visit = 0;
            page.CreateDate = DateTime.Now;
            await _pageService.InsertPage(page);
            await _pageService.Save();
            return RedirectToAction(nameof(Index));

        }

        // GET: Admin/Pages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _pageService.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }
            ViewData["PageGroupId"] = new SelectList(_pageGroupService.GetAllGroups(), "Id", "GroupTitle", page.PageGroupId);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PageGroupId,Title,ShortDiscription,Text,Visit,ImageName,ShowInSlider,CreateDate")] Page page)
        {
            if (id != page.Id)
            {
                return NotFound();
            }


            try
            {
                _pageService.UpdatePage(page);
                await _pageService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(page.Id))
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

        // GET: Admin/Pages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .Include(p => p.PageGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pages == null)
            {
                return Problem("Entity set 'ParsaDbContext.Pages'  is null.");
            }
            var page = await _context.Pages.FindAsync(id);
            if (page != null)
            {
                _context.Pages.Remove(page);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return (_context.Pages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
