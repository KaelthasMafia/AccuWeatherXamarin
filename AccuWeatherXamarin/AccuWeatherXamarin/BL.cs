using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AccuWeatherXamarin
{
    public class BL
    {
        public static bool StringIsValid(string str)
        {
            return !string.IsNullOrEmpty(str) && !Regex.IsMatch(str, @"(^[^a-zA-Z- ]|[^a-zA-Z- ])");
        }
    }
}
