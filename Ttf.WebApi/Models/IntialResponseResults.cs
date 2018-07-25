using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ttf.WebApi.Models
{
    public class IntialResponseResults
    {
        public List<RoomResults> RoomList { get; set; }
        public List<FeatureResults> FeatureList { get; set; }
        public List<RoomsFeatureResults> MappingList { get; set; }
    }
}