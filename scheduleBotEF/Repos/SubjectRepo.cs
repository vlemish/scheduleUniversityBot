using scheduleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Repos
{
    public class SubjectRepo : BaseRepo<Subject>
    {
        public Subject GetOne(string subjectName)
        {
            return Context.Subjects.Where(s => s.SubjectName.Equals(subjectName)).Select(s => s).FirstOrDefault();
        }
    }
}
