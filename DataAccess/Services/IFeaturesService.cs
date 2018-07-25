using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public interface IFeaturesService
    {
        Task<List<Features>> GetAllBlogByPageIndex(int pageIndex, int pageSize);
    }
}
