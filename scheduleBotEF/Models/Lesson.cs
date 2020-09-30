using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    class Lesson
    {
        public int Id { get; set; }

        public DateTime LessonTime { get; set; }

        public int EvenOrOdd { get; set; }


        //FK_GroupToLesson
        public int GroupId { get; set; }
        public Group Groups { get; set; }

        //FK_TeacherToLesson
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }
    }
}
