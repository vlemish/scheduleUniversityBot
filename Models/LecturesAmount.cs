using scheduleDbLayer.Models;
using scheduleDbLayer.Repos;
using System;
using System.Collections.Generic;

namespace telegramBotASP.Models
{
    static class LecturesAmount
    {
        private static int GetAmountOfLectures(DateTime startPoint, DateTime endPoint, Subject subject, List<Lesson> lessons)
        {
            var lecturesCount = 0;

            foreach (var lesson in lessons)
            {
                var temp = startPoint.AddDays((int)lesson.DayOfWeek - 1);
                var daysToAdd = 0;

                if (lesson.EvenOrOdd != 0)
                    daysToAdd = 14;
                else
                    daysToAdd = 7;

                while (temp <= endPoint)
                {
                    lecturesCount++;
                    temp = temp.AddDays(daysToAdd);
                }
            }
            return lecturesCount;
        }

        public static int GetAmount(Subject subject, DateTime startPoint, DateTime endPoint)
        {
            var lessons = new LessonRepo().GetAllLessons(subject.Id);

            return GetAmountOfLectures(startPoint, endPoint, subject, lessons);
        }
    }
}