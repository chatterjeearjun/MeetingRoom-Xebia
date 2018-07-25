using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IInitialResponseRepository : IGenericRepository<IntialResponse>
    {
        Task<List<IntialResponse>> GetAllBlogByPageIndex(int pageIndex, int pageSize);
    }
}
