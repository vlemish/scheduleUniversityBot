using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    public class Lesson
    {
        public Lesson(TimeSpan lessonTime, int evenOrOdd, int groupId, int teacherId, int subjetId, DayOfWeek dayOfWeek)
        {
            LessonTime = lessonTime;
            EvenOrOdd = evenOrOdd;
            GroupId = groupId;
            TeacherId = teacherId;
            DayOfWeek = dayOfWeek;
            SubjectId = subjetId;
        }

        public Lesson()
        {

        }

        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan LessonTime { get; set; }

        public int EvenOrOdd { get; set; }


        //FK_GroupToLesson
        public int GroupId { get; set; }
        public virtual Group Groups { get; set; }
        
        //FK_SubjectToLesson
        public int SubjectId { get; set; }
        public virtual Subject Subjects { get; set; }

        //FK_TeacherToLesson
        public int TeacherId { get; set; }
        public virtual Teacher Teachers { get; set; }
    }
}
