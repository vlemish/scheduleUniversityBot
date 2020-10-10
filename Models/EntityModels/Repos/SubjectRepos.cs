using scheduleUniversityDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleUniversityBot.Repos
{
    abstract class SubjectRepos
    {
        public static string GetSubjectInfo(string subjectName)
        {

            using (var context = new ScheduleEntities())
            {
                var subjects = context.Subjects_.Where(i => i.SubjectName == subjectName);
                string s = "";
                foreach (var subject in subjects) { s += subject; }
                return s;
            }
        }
    }
}