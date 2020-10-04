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
        public override int AddRange(IList<SubjectTeachers> entities)
        {
            var sql = "INSERT INTO SubjectTeachers VALUES" +
                string.Join(", ", entities.Select(e => $"(SubjectId={e.SubjectId}, TeacherId={e.TeacherId})"));

            Context.SubjectTeachers.SqlQuery(sql);

            return 0;
        }
    }
}
