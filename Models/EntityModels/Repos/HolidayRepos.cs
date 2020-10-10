using scheduleUniversityDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace scheduleUniversityBot.Repos
{
    abstract class HolidayRepos
    {
        public static bool IsHoliday(DateTime date, ref string nameOfHolday)
        {
            using (var context = new ScheduleEntities())
            {
                var avaliableHolidays = context.Holidays.Where(holiday => holiday.From <= date.Date && holiday.To >= date.Date).First();
                nameOfHolday = avaliableHolidays.Name;
                if (nameOfHolday != null || nameOfHolday != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}