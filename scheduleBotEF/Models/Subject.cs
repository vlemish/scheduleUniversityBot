using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace scheduleDbLayer.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public Subject(string subjectName)
        {
            SubjectName = subjectName;
        }

        public Subject()
        {
                
        }

        public ICollection<Teacher> Teachers { get; set; }

        public ICollection<Group> Groups { get; set; }

    }
}
