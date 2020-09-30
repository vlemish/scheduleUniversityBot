using System;
using System.Collections.Generic;
using System.Text;

namespace scheduleDbLayer.Models
{
    class Group
    {
        public int Id { get; set; }

        public string GroupName { get; set; }
        
        //FK_FacultyToGroup
        public int FacultyId { get; set; }


        public Faculty Faculties { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<Subject> Subjects { get; set; }

    }
}
