using System;
using System.Collections.Generic;
using System.Text;

namespace AccuWeatherXamarin.Models
{
    public class MainPageViewModel
    {
        public Weather Weather { get; set; }

        public List<string> Cities;
    }
}
