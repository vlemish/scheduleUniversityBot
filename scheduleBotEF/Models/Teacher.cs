using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleTelegramBotDb.Models
{
    class Teacher
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public ICollection<GroupSubjects> GroupSubjects { get; set; }

        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }
    }
}
