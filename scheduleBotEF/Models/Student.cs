using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleTelegramBotDb.Models
{
    class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        //public ICollection<Groups> Groups { get; set; }

        public Group Groups { get; set; }
    }
}
