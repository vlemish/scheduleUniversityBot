using System;
using telegramBotASP.Models.Facades;

namespace scheduleUniversityBot_net.Models.Commands.Days
{
    public class Monday : WorkingDay
    {
        public Monday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }

        protected override string GetEvenSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Monday);

        protected override string GetOddSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Monday);
    }

    public class Tuesday : WorkingDay
    {
        public Tuesday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetEvenSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Tuesday);

        protected override string GetOddSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Tuesday);
    }



    public class Wendnesday : WorkingDay
    {

        public Wendnesday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetEvenSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Wednesday);

        protected override string GetOddSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Wednesday);
    }


    public class Thursday : WorkingDay
    {
        public Thursday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetOddSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Thursday);

        protected override string GetEvenSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Thursday);
    }


    public class Friday : WorkingDay
    {
        public Friday(bool even, string username, string lastname, string firstname)
            : base(even, username, lastname, firstname) { }
        protected override string GetOddSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(1, DayOfWeek.Friday);

        protected override string GetEvenSchedule() => new ScheduleFacade(Username, LastName, FirstName).GetSchedule(2, DayOfWeek.Friday);
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