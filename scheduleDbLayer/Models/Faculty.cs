using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        public string FacultyName { get; set; }

        public Faculty(string facultyName)
        {
            FacultyName = facultyName;
        }

        public Faculty()
        {

        }

        public ICollection<Student> Students { get; set; }

        public ICollection<Group> Groups{ get; set; }
    }
}
