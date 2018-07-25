using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class RoomsService : IRoomsService
    {
        IUnitOfWork _unitOfWork;
        public RoomsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Rooms>> GetAllBlogByPageIndex(int pageIndex, int pageSize)
        {
            return await _unitOfWork.RoomsRepository.GetAllBlogByPageIndex(pageIndex, pageSize);
        }
    }
}
