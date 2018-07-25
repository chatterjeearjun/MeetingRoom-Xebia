using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ttf.BusinessLayer.Foo.Dto
{
    public class RoomConfirmBooking
    {
        public int RoomID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
    }
}
