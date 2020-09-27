using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer.Types
{
    class Teacher : ITableEntity
    {
        public Teacher( int teacherId, string subjectName)
        {
            Id = teacherId;
            TeacherName = subjectName;
        }

        public Teacher(string subjectName)
        {          
            TeacherName = subjectName;
        }

        public Teacher() { }


        public int Id { get; set; }

        public string TeacherName { get; set; }
    }
}
