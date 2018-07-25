using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IConfirmBookingRepository : IGenericRepository<RoomConfirmBooking>
    {
        Task<List<RoomConfirmBooking>> GetAllBlogByPageIndex(int pageIndex, int pageSize);
    }
}
