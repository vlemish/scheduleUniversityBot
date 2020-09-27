using ScheduleTelegramBotDb.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleTelegramBotDb.Models
{
    class Group
    {
        public int Id { get; set; }

        public string GroupName { get; set; }
        
        public ICollection<Student> Students { get; set; }

        public ICollection<GroupSubjects> GroupSubjects { get; set; }

        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }
    }
}
