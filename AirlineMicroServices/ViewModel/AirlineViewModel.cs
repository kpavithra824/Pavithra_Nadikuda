﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMicroServices.ViewModel
{
    public class AirlineViewModel
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        //List<FlightViewModel> lst = new List<FlightViewModel>(); 
    }
}
