using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scheduleUniversityBot.Models
{
    public abstract class AppSettings
    {
        public static string Url { get; set; } = "your host url"

        public static string Name { get; set; } = "your bot name";

        public static string Key { get; set; } = "your bot API key";

    }
}
