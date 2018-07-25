using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRoomsFeatureRepository : IGenericRepository<RoomsFeatures>
    {
        Task<List<RoomsFeatures>> GetAllBlogByPageIndex(int pageIndex, int pageSize);
    }
}
