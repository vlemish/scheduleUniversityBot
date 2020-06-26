using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scheduleUniversityBot.Models
{
    public abstract class AppSettings
    {
        public static string Url { get; set; } = "https://scheduleuniversitybot.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "scheduleUniversityBot";

        public static string Key { get; set; } = "825359183:AAHo6llTff5xCKR_HfkFzlaiZfIa9EnwZtw";

    }
}
