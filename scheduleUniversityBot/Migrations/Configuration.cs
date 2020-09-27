namespace scheduleUniversityBot_net.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using testDbMySql.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<scheduleUniversityDb.EF.ScheduleEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(scheduleUniversityDb.EF.ScheduleEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var teachers = new List<Teacher>
            {
                new Teacher { TeacherName= "Біньковська А.Б." },//0
                new Teacher { TeacherName="Філь Н.Ю."},//1
                new Teacher { TeacherName="Крайнюк О.В."},//2
                new Teacher { TeacherName="Кудирко О.М."},//3
                new Teacher { TeacherName="Кононихін О.С."},//4
                new Teacher { TeacherName="Гурко О.Г."},//5
                new Teacher { TeacherName="Філь Н.Ю."}//6
            };

            context.Teachers_.AddOrUpdate(x => new { x.TeacherName });

            var subjects = new List<Subject>
            {
                new Subject { SubjectName="Конструирование электронных устройств", TypeOfExam="Іспит", CourseWork="КП", Teacher=teachers[0]},//0
                new Subject { SubjectName="Системний аналіз", TypeOfExam="Іспит", CourseWork="РГР", Teacher=teachers[1]},//1
                new Subject { SubjectName="Основи охорони праці", TypeOfExam="Ісп", CourseWork="-_-", Teacher=teachers[2]},//2
                new Subject { SubjectName="Науково-дослідницька робота", TypeOfExam="Залік", CourseWork="-_-",Teacher=teachers[3]},//3
                new Subject { SubjectName="Автоматизовані системи керування експериментом", TypeOfExam="Залік", CourseWork="РГР", Teacher=teachers[4]},//4
                new Subject { SubjectName="Гнучке автоматизоване виробництво і робото-технічні комплекси", TypeOfExam="Іспит", CourseWork="РГР", Teacher=teachers[5]},//5
                new Subject { SubjectName="Комп''ютерні системи управління", TypeOfExam="Іспит", CourseWork="РГР", Teacher=teachers[6]}//6
            };
            context.Subjects_.AddOrUpdate(x => new { x.SubjectName }, subjects.ToArray());

            var monday = new List<Monday>
                {
                    new Monday { EvenOrOdd=3, lectureTime=TimeSpan.Parse("10:30"), Teachers=teachers[0],Subjects=subjects[0], TypeOfLecture="Лекція"},
                    new Monday { EvenOrOdd=3,  lectureTime=TimeSpan.Parse("12:30"),Teachers=teachers[0],Subjects=subjects[0], TypeOfLecture="Практика"}
                };
            monday.ForEach(i => context.Mondays.AddOrUpdate(x => new { x.EvenOrOdd, x.lectureTime }, i));

            var tuesday = new List<Tuesday>
                {
                    new Tuesday{ EvenOrOdd=3, lectureTime=TimeSpan.Parse("10:30"),Teachers=teachers[1],Subjects=subjects[1], TypeOfLecture="Лекція"},
                    new Tuesday{ EvenOrOdd=3, lectureTime=TimeSpan.Parse("12:30"),Teachers=teachers[1],Subjects=subjects[1], TypeOfLecture="Практика"}
                };
            tuesday.ForEach(i => context.Tuesdays.AddOrUpdate(x => new { x.EvenOrOdd, x.lectureTime }, i));

            var wednesday = new List<Wednesday>
                {
                    new Wednesday{ EvenOrOdd=1, lectureTime=TimeSpan.Parse("8:45"), Teachers=teachers[2], Subjects=subjects[2], TypeOfLecture="Практика"},
                    new Wednesday{ EvenOrOdd=1, lectureTime=TimeSpan.Parse("10:30"),Teachers=teachers[3], Subjects=subjects[3], TypeOfLecture="Практика"},
                    new Wednesday{ EvenOrOdd=1, lectureTime=TimeSpan.Parse("12:30"),Teachers=teachers[5], Subjects=subjects[5], TypeOfLecture="Лекція"},
                    new Wednesday{ EvenOrOdd=2, lectureTime=TimeSpan.Parse("8:45"), Teachers=teachers[2], Subjects=subjects[2], TypeOfLecture="Лекція"},
                    new Wednesday{ EvenOrOdd=2, lectureTime=TimeSpan.Parse("10:30"),Teachers=teachers[4], Subjects=subjects[4], TypeOfLecture="Практика"},
                    new Wednesday{ EvenOrOdd=2, lectureTime=TimeSpan.Parse("12:30"),Teachers=teachers[5], Subjects=subjects[5], TypeOfLecture="Лекція"},

                };
            wednesday.ForEach(i => context.Wednesdays.AddOrUpdate(x => new { x.EvenOrOdd, x.TypeOfLecture, x.lectureTime }, i));

            var thursday = new List<Thursday>
                {
                    new Thursday{EvenOrOdd=3, lectureTime=TimeSpan.Parse("10:30"), Teachers=teachers[6], Subjects=subjects[6], TypeOfLecture="Лекція"},
                    new Thursday{EvenOrOdd=3, lectureTime=TimeSpan.Parse("12:30"), Teachers=teachers[6], Subjects=subjects[6], TypeOfLecture="Практика"}

                };
            thursday.ForEach(i => context.Thursdays.AddOrUpdate(x => new { x.EvenOrOdd, x.lectureTime, x.Id }, i));

            var friday = new List<Friday>
                {
                    new Friday{EvenOrOdd=1,lectureTime=TimeSpan.Parse("10:30"), Teachers=teachers[4], Subjects=subjects[4], TypeOfLecture="Практика" },
                    new Friday{EvenOrOdd=1,lectureTime=TimeSpan.Parse("12:30"), Teachers=teachers[5], Subjects=subjects[5], TypeOfLecture="Практика"},
                    new Friday{EvenOrOdd=2,lectureTime=TimeSpan.Parse("12:30"), Teachers=teachers[5], Subjects=subjects[5], TypeOfLecture="Практика" }
                };
            friday.ForEach(i => context.Fridays.AddOrUpdate(x => new { x.EvenOrOdd, x.lectureTime }, i));

        }
    }
}
