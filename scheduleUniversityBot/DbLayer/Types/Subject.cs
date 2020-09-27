using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer.Types
{
    class Subject : ITableEntity
    {
        public Subject(int subjectId, int teacherId, string subjectName)
        {
            Id = subjectId;
            TeacherId = teacherId;
            SubjectName = subjectName;
        }

        public Subject(int teacherId, string subjectName)
        {
            TeacherId = teacherId;
            SubjectName = subjectName;
        }

        public Subject() { }

        public int Id { get; set; }

        public int TeacherId { get; set; }

        public string SubjectName { get; set; }
    }
}
