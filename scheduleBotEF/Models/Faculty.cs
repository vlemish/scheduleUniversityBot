using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    class Faculty
    {
        public int Id { get; set; }

        public string FacultyName { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Group> Groups{ get; set; }
    }
}
