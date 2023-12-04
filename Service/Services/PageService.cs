using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PageService : IPage
    {
        ParsaDbContext _context;
        public PageService(ParsaDbContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<Page> GetAllPages()
        {
            return _context.Pages.ToList();
        }
        public async Task<Page> GetPageById(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            return (page);
        }
        public async Task<bool> InsertPage(Page page)
        {
            try
            {
                await _context.Pages.AddAsync(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePage(Page page)
        {
            try
            {
                _context.Pages.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public bool DeletePage(Page page)
        {
            try
            {
                _context.Pages.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePage(int PageId)
        {
            try
            {
                var page = await GetPageById(PageId);
                DeletePage(page);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
