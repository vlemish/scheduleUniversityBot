using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scheduleBot.Models
{
    public abstract class AppSettings
    {
        public static string Url { get; set; } = "https://telegrambotasp20200929195420.azurewebsites.net:443/{0}";//

        public static string Name { get; set; } = "scheduleUniversityBot";

        public static string Key { get; set; } = @"825359183:AAGcDxwSMoD5FMW_lWsQA-TcmeWY0wUgNZI";
        //825359183:AAF3RWirEVg546WoqmMkaBlrapXYPYmM8Hk

    }
}
