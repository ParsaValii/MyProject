using Domain.Entities;
using Domain;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PageGroupService : IPageGroup
    {
        ParsaDbContext _context;
        public PageGroupService(ParsaDbContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<PageGroup> GetAllGroups()
        {
            return _context.PageGroups;
        }

        public async Task<PageGroup> GetGroupById(int id)
        {
            var group = await _context.PageGroups.FindAsync(id);
            return group;
        }

        public async Task<bool> InsertGroup(PageGroup pageGroup)
        {
            try
            {
                await _context.PageGroups.AddAsync(pageGroup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateGroup(PageGroup pageGroup)
        {
            try
            {
                _context.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGroup(PageGroup pageGroup)
        {
            try
            {
                _context.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteGroup(int groupId)
        {
            try
            {
                var group = await GetGroupById(groupId);
                DeleteGroup(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
