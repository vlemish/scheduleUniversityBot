using scheduleUniversityBot.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scheduleUniversityBot_net.Models.Commands.Days
{
   abstract public class DefineDate
    {
        public static WorkingDay GetDay(DateTime dt)
        {
            int day = Math.Abs( 13 - dt.Day);
            bool isEven = day % 2 != 0;
            string msg = "";
            //bool isHoliday = HolidayRepos.IsHoliday(dt, ref msg);
            //if (isHoliday)
            //{
            //    return new Holiday(isEven,msg);
            //}
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        return new Monday(isEven);

                    }
                case DayOfWeek.Tuesday:
                    {
                        return new Tuesday(isEven);
                    }
                case DayOfWeek.Wednesday:
                    {
                        return new Wendnesday(isEven);
                    }
                case DayOfWeek.Thursday:
                    {
                        return new Thursday(isEven);
                    }
                case DayOfWeek.Friday:
                    {
                        return new Friday(isEven);
                    }
                default:
                    {
                        return new Weekend(isEven);
                    }
            }
        }
        public static WorkingDay GetDay(DateTime dt, int day)
        {

            day =Math.Abs( 13 - (dt.Day+day));
            bool isEven = day % 2 != 0;
            string msg = "";
            //bool isHoliday = HolidayRepos.IsHoliday(dt, ref msg);
            //if (isHoliday)
            //{
            //    return new Holiday(isEven, msg);
            //}
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        return new Tuesday(isEven);
                    }
                case DayOfWeek.Tuesday:
                    {
                        return new Wendnesday(isEven);
                    }
                case DayOfWeek.Wednesday:
                    {
                        return new Thursday(isEven);
                    }
                case DayOfWeek.Thursday:
                    {
                        return new Friday(isEven);
                    }
                case DayOfWeek.Sunday:
                    {
                        return new Monday(isEven);
                    }
                default:
                    {
                        return new Weekend(isEven);
                    }

            }
        }
        public static WorkingDay GetDay(DateTime dt, DayOfWeek dayOfWeak, int i)
        {

            int day =Math.Abs(13- (dt.Day+ i));
            bool isEven = day % 2 != 0;
            string msg = "";
            //bool isHoliday = HolidayRepos.IsHoliday(dt, ref msg);
            //if (isHoliday)
            //{
            //    return new Holiday(isEven, msg);
            //}

            switch (dayOfWeak)
            {
                case DayOfWeek.Monday:
                    {

                        return new Monday(isEven);

                    }
                case DayOfWeek.Tuesday:
                    {

                        return new Tuesday(isEven);
                    }
                case DayOfWeek.Wednesday:
                    {

                        return new Wendnesday(isEven);
                    }
                case DayOfWeek.Thursday:
                    {

                        return new Thursday(isEven);
                    }
                case DayOfWeek.Friday:
                    {

                        return new Friday(isEven);
                    }
                default:
                    {

                        return new Weekend(isEven);
                    }
            }
        }
    }
}
