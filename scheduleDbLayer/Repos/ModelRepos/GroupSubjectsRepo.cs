using scheduleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Repos
{
    public class GroupSubjectsRepo:BaseRepo<GroupSubjects>
    {

        public List<GroupSubjects> GetAllAssociatedGroups(int groupId) => Context.GroupSubjects.Where(gs => gs.GroupId.Equals(groupId)).Select(gs => gs).ToList();

        public List<GroupSubjects> GetAllAssociatedSubjects(int subjectId) => Context.GroupSubjects.Where(gs => gs.SubjectId.Equals(subjectId)).Select(gs => gs).ToList();

    }
}
