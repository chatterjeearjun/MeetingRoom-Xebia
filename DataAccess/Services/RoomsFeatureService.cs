using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class RoomsFeatureService : IRoomsFeatureService
    {
        IUnitOfWork _unitOfWork;
        public RoomsFeatureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<RoomsFeatures>> GetAllBlogByPageIndex(int pageIndex, int pageSize)
        {
            return await _unitOfWork.RoomsFeatureRepository.GetAllBlogByPageIndex(pageIndex, pageSize);
        }
    }
}
