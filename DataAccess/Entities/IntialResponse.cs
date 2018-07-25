using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Entities
{
    public class IntialResponse
    {
        public List<Rooms> RoomList { get; set; }
        public List<Features> FeatureList { get; set; }
        public List<RoomsFeatures> MappingList { get; set; }
    }
}