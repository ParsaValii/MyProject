using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPageGroupService : IDisposable
    {
        IEnumerable<PageGroup> GetAllGroups();
        Task<PageGroup> GetGroupById(int id);
        Task<bool> InsertGroup(PageGroup pageGroup);
        bool UpdateGroup(PageGroup pageGroup);
        bool DeleteGroup(PageGroup pageGroup);
        Task<bool> DeleteGroup(int groupId);
        Task Save();
    }
}
