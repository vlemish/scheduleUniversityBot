using ScheduleTelegramBotDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleTelegramBotDb.Models
{
    class GroupSubjects
    {
        public int GroupId { get; set; }

        public Group Group { get; set; }


        public int SubjectId { get; set; }
        
        public Subject Subject { get; set; }
    }
}
