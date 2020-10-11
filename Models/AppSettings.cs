using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scheduleBot.Models
{
    public abstract class AppSettings
    {
        public static string Url { get; set; } = "https://URL:443/{0}";

        public static string Name { get; set; } = "scheduleUniversityBot";

        public static string Key { get; set; } = @"API";
        
    }
}
