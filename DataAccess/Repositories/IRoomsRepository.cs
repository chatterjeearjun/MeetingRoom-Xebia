using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRoomsRepository : IGenericRepository<Rooms>
    {
        Task<List<Rooms>> GetAllBlogByPageIndex(int pageIndex, int pageSize);
    }
}
