﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ttf.WebApi.Models
{
    public class RoomsFeatureResults
    {
        public int RoomID { get; set; }
        public int FeatureID { get; set; }
        public string RoomName { get; set; }
        public string FeatureName { get; set; }
    }
}