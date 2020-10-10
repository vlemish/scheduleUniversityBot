using scheduleDbLayer.Models;
using System;
namespace scheduleUniversityBot_net.Models.Commands.Days
{
    public class Monday : WorkingDay
    {
        public Monday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }

        protected override string GetEvenSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Monday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Monday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;

        }

        protected override string GetOddSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Monday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Monday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;
        }
    }

    public class Tuesday : WorkingDay
    {
        public Tuesday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetEvenSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Tuesday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Tuesday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;
        }

        protected override string GetOddSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Tuesday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Tuesday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;
        }
    }



    public class Wendnesday : WorkingDay
    {

        public Wendnesday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetEvenSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Wednesday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Wednesday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;

        }

        protected override string GetOddSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Wednesday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Wednesday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;
        }
    }


    public class Thursday : WorkingDay
    {
        public Thursday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetOddSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Thursday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Thursday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;
        }

        protected override string GetEvenSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Thursday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Thursday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;
        }
    }


    public class Friday : WorkingDay
    {
        public Friday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetOddSchedule()
        {
            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Thursday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Thursday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;

        }
        protected override string GetEvenSchedule()
        {

            var _schedule = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Friday);

            if (_schedule == "")
            {
                var scheduleGeneric = new ScheduleFacade(Username, LastName, FirstName).GetSchedule(0, DayOfWeek.Friday);

                if (scheduleGeneric != "")
                {
                    return scheduleGeneric;
                }

                else return "Day off";
            }

            return _schedule;
        }
    }
    public class Weekend : WorkingDay
    {
        public Weekend(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetEvenSchedule()
        {
            return "O T D I X";
        }

        protected override string GetOddSchedule()
        {
            return GetEvenSchedule();
        }
    }
    public class Holiday : WorkingDay
    {
        public string Cause { get; set; }
        public Holiday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }

        protected override string GetEvenSchedule()
        {
            return $"Відпочивай, сьогодні {Cause}";
        }
        protected override string GetOddSchedule()
        {
            return GetEvenSchedule();
        }
    }
}