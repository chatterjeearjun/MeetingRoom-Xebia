using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class ConfirmBookingService : IConfirmBookingService
    {
        IUnitOfWork _unitOfWork;
        public ConfirmBookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<RoomConfirmBooking>> GetAllBlogByPageIndex(int pageIndex, int pageSize)
        {
            return await _unitOfWork.ConfirmBookingRepository.GetAllBlogByPageIndex(pageIndex, pageSize);
        }
    }
}
