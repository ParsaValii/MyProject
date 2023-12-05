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
    public class PageGroupsController : Controller
    {
        private readonly ParsaDbContext _context;
        PageGroupService _pagegroupService;

        public PageGroupsController(ParsaDbContext context, PageGroupService pageGroupService)
        {
            _pagegroupService = pageGroupService;
            _context = context;
        }

        // GET: Admin/PageGroups
        public async Task<IActionResult> Index()
        {
              return _context.PageGroups != null ? 
                          View(await _context.PageGroups.ToListAsync()) :
                          Problem("Entity set 'ParsaDbContext.PageGroups'  is null.");
        }

        // GET: Admin/PageGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PageGroups == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pageGroup == null)
            {
                return NotFound();
            }

            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pageGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PageGroups == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroups.FindAsync(id);
            if (pageGroup == null)
            {
                return NotFound();
            }
            return View(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupTitle")] PageGroup pageGroup)
        {
            if (id != pageGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageGroupExists(pageGroup.Id))
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
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PageGroups == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pageGroup == null)
            {
                return NotFound();
            }

            return View(pageGroup);
        }

        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PageGroups == null)
            {
                return Problem("Entity set 'ParsaDbContext.PageGroups'  is null.");
            }
            var pageGroup = await _context.PageGroups.FindAsync(id);
            if (pageGroup != null)
            {
                _context.PageGroups.Remove(pageGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageGroupExists(int id)
        {
          return (_context.PageGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
