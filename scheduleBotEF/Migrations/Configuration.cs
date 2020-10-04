namespace scheduleDbLayer.Migrations
{
    using scheduleDbLayer.Models;
    using scheduleDbLayer.Repos;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<scheduleDbLayer.EF.ScheduleEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(scheduleDbLayer.EF.ScheduleEntities context)
        {

            //TEACHERS
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Філь Н.Ю."), //2
                new Teacher("Кононихін О.С."),//3
                new Teacher("Петренко Ю.А."), //4
                new Teacher("Нефьодов Л.І."),//5
                new Teacher("Біньковска А.Б."),//6
                new Teacher("Поляков Є.О.")//7
            };

            var teachersRepo = new TeacherRepo();
            teachersRepo.AddRange(teachers);
            context.Teachers.AddOrUpdate(x => new { x.TeacherName });

            //Faculties
            BaseRepo<Faculty> _repoFaculty = new BaseRepo<Faculty>();

            _repoFaculty.AddRange(new List<Faculty>()
            {
                new Faculty() { FacultyName = "Mechanical" },
                new Faculty() { FacultyName = "Automobile" }
            });

            context.Faculties.AddOrUpdate(x => new { x.FacultyName });

            //Groups
            BaseRepo<Group> _repoGroups = new BaseRepo<Group>();
            _repoGroups.Add(new Group() { GroupName = "MA51-20", FacultyId = 1 });
            context.Groups.AddOrUpdate(x => new { x.GroupName });

            //Subjects
            List<Subject> subjects = new List<Subject>()
            {
                new Subject("Автоматизація наукових досліджень"), //2
                new Subject("Автоматизовані банки даних АСУТП"),//3
                new Subject("Системи керування зі штучним інтелектом"),//4
                new Subject("Сенсорні мережі АСУТП"),//5
                new Subject("Комп'ютерне управління технологічними процесами"), //6
                new Subject("САПР в АСУ"),//7
                new Subject("Кваліфікаційна робота"),//8
                new Subject("Управління проектами корпоративних комп'ютерних систем"),//9
                new Subject("Технологічні вимірювання та прилади")//10

            };

            var _repoSubjects = new SubjectRepo();
            _repoSubjects.AddRange(subjects);
            context.Subjects.AddOrUpdate(x => new { x.SubjectName });

            List<SubjectTeachers> subjectTeachers = new List<SubjectTeachers>()
            {
                new SubjectTeachers(2,2),
                new SubjectTeachers(2,3),
                new SubjectTeachers(3,5),
                new SubjectTeachers(4,6),
                new SubjectTeachers(5,7),
                new SubjectTeachers(5,8),
                new SubjectTeachers(5,9),
                new SubjectTeachers(6,4),
                new SubjectTeachers(7,10)
            };

            var repoTeacherSubjects = new SubjectTeachersRepo();
            repoTeacherSubjects.AddRange(subjectTeachers);

        }
    }
}
