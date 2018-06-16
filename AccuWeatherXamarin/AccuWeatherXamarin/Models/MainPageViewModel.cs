using System;
using System.Collections.Generic;
using System.Text;

namespace AccuWeatherXamarin.Models
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            Weather = new Weather();
            Cities = new List<string>();
        }

        public Weather Weather { get; set; }

        public List<string> Cities;
    }
}
