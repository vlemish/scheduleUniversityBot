using scheduleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Repos
{
    public class TeacherRepo : BaseRepo<Teacher>
    {
        public Teacher GetOne(string teacherName)
        {
            return Context.Teachers.Where(t => t.TeacherName.Equals(teacherName)).Select(t => t).FirstOrDefault();
        }
    }
}
