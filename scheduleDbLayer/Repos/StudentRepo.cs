using scheduleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Repos
{
    public class StudentRepo : BaseRepo<Student>
    {

        public Student GetOne(string userName, string lastName, string firstName)
        {
            bool isUserName = userName != null;
            bool isLastName = lastName != null;

            if (isUserName)
            {
                return Context.Students.Where(s => s.UserName.Equals(userName)).Select(s=>s).FirstOrDefault();
            }

            else if (isLastName)
            {
                return Context.Students.Where(s => s.LastName.Equals(lastName)).Select(s => s).FirstOrDefault();
            }

            return Context.Students.Where(s => s.FirstName.Equals(firstName)).Select(s => s).FirstOrDefault();
        }
    }
}
