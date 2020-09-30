using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace scheduleDbLayer.Models
{
    class Subject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }



        public ICollection<Teacher> Teachers { get; set; }

        public ICollection<Group> Groups { get; set; }

    }
}
