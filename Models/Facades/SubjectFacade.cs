using scheduleDbLayer.Repos;
using System;
using System.Linq;

namespace telegramBotASP.Models.Facades
{
    public class SubjectFacade
    {
        public string Username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public SubjectFacade(string username, string lastname, string firstname)
        {
            Username = username;
            LastName = lastname;
            FirstName = firstname;
        }

        public SubjectFacade()
        {

        }

        public string GetSubjects(int subjectId)
        {
            var subject = new SubjectRepo().GetOne(subjectId);

            var teacher = new SubjectTeachersRepo().GetAllAssociatedTeachers(subjectId).FirstOrDefault().TeacherName;

            var amountFull = LecturesAmount.GetAmount(subject, new DateTime(2020, 9, 21), new DateTime(2020, 12, 21));
            var amountLeft = LecturesAmount.GetAmount(subject, DateTime.Now, new DateTime(2020, 12, 21));

            return $"{subject.SubjectName}\n{teacher}\nTotal amount of lectures: {amountFull}\nLeft: {amountLeft}";
        }
    }
}