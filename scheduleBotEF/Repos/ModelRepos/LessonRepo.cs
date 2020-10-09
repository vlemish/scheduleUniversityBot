using scheduleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Repos
{
    public class LessonRepo : BaseRepo<Lesson>
    {
        public Lesson GetDailySchedule(int evenOrOdd, int groupId, DayOfWeek dayOfWeek) => Context.Lessons.
            Where(l => l.EvenOrOdd == evenOrOdd && l.GroupId == groupId && l.DayOfWeek == dayOfWeek).
            Select(l=>l).FirstOrDefault();
    }
}
