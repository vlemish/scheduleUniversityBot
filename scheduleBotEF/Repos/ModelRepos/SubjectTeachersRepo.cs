using scheduleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Repos
{
    class SubjectTeachersRepo:BaseRepo<SubjectTeachers>
    {
        public List<SubjectTeachers> GetAllAssociatedSubjects(int subjectId) => Context.SubjectTeachers.Where(st => st.Equals(subjectId)).Select(st => st).ToList();

        public List<SubjectTeachers> GetAllAssociatedTeachers(int teacherId) => Context.SubjectTeachers.Where(st => st.Equals(teacherId)).Select(st => st).ToList();
    }
}
