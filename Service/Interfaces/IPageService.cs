using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPageService
    {
        IEnumerable<Page> GetAllPages();
        Task<Page> GetPageById(int id);
        Task<bool> InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        Task<bool> DeletePage(int PageId);
        Task Save();
    }
}
