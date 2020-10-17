using scheduleBot.Models.Commands;
using scheduleDbLayer.Repos;
using scheduleUniversityBot_net.Models.Commands.Days;
using System;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace scheduleUniversityBot_net.Models.Commands
{
    public class WeekCoomand : Command
    {
        public List<WorkingDay> Weeks;

        public override string Name => @"/week";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Equals(this.Name);
        }

        public override void Execute(Message message, TelegramBotClient botClient)
        {
            var student = new StudentRepo().GetOne(message.From.Username, message.From.LastName, message.From.FirstName);

            var isRegistrated = student != null;

            var chatId = message.Chat.Id;

            if (!isRegistrated)
            {
                botClient.SendTextMessageAsync(chatId, $"You aren't registered, please call /start command to start working with bot.");
            }

            else
            {
                List<DayOfWeek> list = new List<DayOfWeek>()
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Friday,
                };

                for (int i = 0; i < list.Count; i++)
                {
                    WorkingDay day = DefineDate.GetDay(DateTime.Now, list[i], i, message.From.Username, message.From.LastName, message.From.FirstName);
                    botClient.SendTextMessageAsync(chatId, $"{message.Chat.FirstName}, ваш розклад:\n{list[i]}\n{day.GetSchedule()}");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}