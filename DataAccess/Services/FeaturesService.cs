using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class FeaturesService : IFeaturesService
    {
        IUnitOfWork _unitOfWork;
        public FeaturesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Features>> GetAllBlogByPageIndex(int pageIndex, int pageSize)
        {
            return await _unitOfWork.FeaturesRepository.GetAllBlogByPageIndex(pageIndex, pageSize);
        }
    }
}
