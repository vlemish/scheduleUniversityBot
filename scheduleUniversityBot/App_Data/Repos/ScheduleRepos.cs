using scheduleUniversityDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace scheduleUniversityBot.Repos
{
   abstract class ScheduleRepos
    {
        public static string MondaySchedule()
        {
            using (var context = new ScheduleEntities())
            {
                string s = "";
                foreach (var monday in context.Mondays) { s += monday; }
                return s;
            }

        }
        public static string TuesdaySchedule()
        {
            using(var context= new ScheduleEntities())
            {
                string s = "";
                foreach(var tuesday in context.Tuesdays) { s += tuesday; }
                return s;
            }
        }
        public static string WednesdaySchedule(int evenOrOdd)
        {
            using(var context= new ScheduleEntities())
            {
                string s = "";
                var wednesdays = context.Wednesdays.Where(i => i.EvenOrOdd == evenOrOdd);
                foreach(var wednesday in wednesdays) { s += wednesday; }
                return s;
            }
        }
        public static string ThursdaySchedule()
        {
            using(var context = new ScheduleEntities())
            {
                string s = "";
                foreach(var thursday in context.Thursdays) { s += thursday; }
                return s;
            }
        }
        public static string FridaySchedule(int evenOrOdd)
        {
            using(var context = new ScheduleEntities())
            {
                string s = "";
                var fridays = context.Fridays.Where(i => i.EvenOrOdd == evenOrOdd);
                foreach(var friday in fridays) { s += friday; }
                return s;
            }
        }
    }
}
