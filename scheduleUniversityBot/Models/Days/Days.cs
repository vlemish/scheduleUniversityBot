using scheduleUniversityBot.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace scheduleUniversityBot_net.Models.Commands.Days
{
    public class Monday : WorkingDay
    {
        public Monday(bool even)
            : base(even) { }
        
         protected override string GetEvenSchedule()
        {
            return ScheduleRepos.MondaySchedule();
        }

        protected override string GetOddSchedule()
        {
            return GetEvenSchedule();
        }
    }

    public class Tuesday : WorkingDay
    {
        public Tuesday(bool even)
            : base(even) { }
        protected override string GetEvenSchedule()
        {
            return ScheduleRepos.TuesdaySchedule();
        }

        protected override string GetOddSchedule()
        {
            return GetEvenSchedule();
        }
    }



    public class Wendnesday : WorkingDay
    {

        public Wendnesday(bool even)
            : base(even) { }
        protected override string GetEvenSchedule()
        {
            return ScheduleRepos.WednesdaySchedule(2);

        }

        protected override string GetOddSchedule()
        {
            return ScheduleRepos.WednesdaySchedule(1);
        }
    }


    public class Thursday : WorkingDay
    {
        public Thursday(bool even)
            :base(even) { }
        protected override string GetOddSchedule()
        {
            return ScheduleRepos.ThursdaySchedule();
        }

        protected override string GetEvenSchedule()
        {
            return GetEvenSchedule();
        }
    }


    public class Friday : WorkingDay
    {
        public Friday(bool even)
            : base(even) { }
        protected override string GetOddSchedule()
        {
            return ScheduleRepos.FridaySchedule(1);
        }
        protected override string GetEvenSchedule()
        {
            return ScheduleRepos.FridaySchedule(2);
        }
    }
    public class Weekend : WorkingDay
    {
        public Weekend(bool even)
            : base(even) { }
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
        public Holiday(bool even,string cause)
            : base(even)
        {
            Cause = cause;
        }
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
