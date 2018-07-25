using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ttf.WebApi.Models
{
    public class GridFilterDataOfRoom
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public List<FeatureResults> Features{ get; set; }
    }

    public class GridFilterDataOfFeature
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public List<RoomResults> Rooms { get; set; }
    }
}