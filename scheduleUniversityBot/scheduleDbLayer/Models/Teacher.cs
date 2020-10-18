using System;
using System.Collections.Generic;
using System.Text;

namespace scheduleDbLayer.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public Teacher(string teacherName)
        {
            TeacherName = teacherName;
        }

        public Teacher()
        {

        }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
