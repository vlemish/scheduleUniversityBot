using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ScheduleTelegramBotDb.Models
{
    class Subject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }
        

        public ICollection<GroupSubjects> GroupSubjects { get; set; }

        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }

        public Group Groups { get; set; }

    }
}
