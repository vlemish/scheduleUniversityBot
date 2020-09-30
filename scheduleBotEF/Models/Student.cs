using System;
using System.Collections.Generic;
using System.Text;

namespace scheduleDbLayer.Models
{
    class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

    
        //FK_FacultyToStudent
        public int FacultyId { get; set; }
        public Faculty Faculties { get; set; }

        //FK_GroupToStudent
        public int GroupId { get; set; }
        public Group Groups { get; set; }
    }
}
