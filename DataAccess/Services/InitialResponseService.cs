using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class InitialResponseService : IInitialResponseService
    {
        IUnitOfWork _unitOfWork;
        public InitialResponseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<IntialResponse>> GetAllBlogByPageIndex(int pageIndex, int pageSize)
        {
            return await _unitOfWork.InitialResponseRepository.GetAllBlogByPageIndex(pageIndex, pageSize);
        }
    }
}
