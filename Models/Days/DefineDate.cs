using System;

namespace scheduleUniversityBot_net.Models.Commands.Days
{
    abstract public class DefineDate
    {
        public static WorkingDay GetDay(DateTime dt, string username, string lastname, string firstname)
        {
            int day = Math.Abs(12 - dt.Day);
            bool isEven = day % 2 == 0;
            string msg = "";

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        return new Monday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Tuesday:
                    {
                        return new Tuesday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Wednesday:
                    {
                        return new Wendnesday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Thursday:
                    {
                        return new Thursday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Friday:
                    {
                        return new Friday(isEven, username, lastname, firstname);
                    }
                default:
                    {
                        return new Weekend(isEven, username, lastname, firstname);
                    }
            }
        }
        public static WorkingDay GetDay(DateTime dt, int day, string username, string lastname, string firstname)
        {

            day = Math.Abs(12 - (dt.Day + day));
            bool isEven = day % 2 == 0;
            string msg = "";

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        return new Tuesday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Tuesday:
                    {
                        return new Wendnesday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Wednesday:
                    {
                        return new Thursday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Thursday:
                    {
                        return new Friday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Sunday:
                    {
                        return new Monday(isEven, username, lastname, firstname);
                    }
                default:
                    {
                        return new Weekend(isEven, username, lastname, firstname);
                    }

            }
        }
        public static WorkingDay GetDay(DateTime dt, int includeWeekend, DayOfWeek dayOfWeak, int i, string username, string lastname, string firstname)
        {
            int day = Math.Abs(12 - (dt.Day + i)) + includeWeekend;
            bool isEven = day % 2 == 0;
            string msg = "";

            switch (dayOfWeak)
            {
                case DayOfWeek.Monday:
                    {
                        return new Monday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Tuesday:
                    {
                        return new Tuesday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Wednesday:
                    {
                        return new Wendnesday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Thursday:
                    {
                        return new Thursday(isEven, username, lastname, firstname);
                    }
                case DayOfWeek.Friday:
                    {
                        return new Friday(isEven, username, lastname, firstname);
                    }
                default:
                    {
                        return new Weekend(isEven, username, lastname, firstname);
                    }
            }
        }
    }
}