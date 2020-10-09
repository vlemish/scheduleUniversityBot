using scheduleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Repos
{
    public class FacultyRepo : BaseRepo<Faculty>
    {

        public Faculty GetOne(string facultyName)
        {
            return Context.Faculties.Where(f => f.FacultyName.Equals(facultyName)).Select(f => f).FirstOrDefault();
        }

        public override List<Faculty> GetAll()
        {
            return Context.Faculties.ToList();
        }
    }
}
