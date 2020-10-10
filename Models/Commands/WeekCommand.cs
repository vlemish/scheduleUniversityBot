using scheduleBot.Models.Commands;
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
            var chatId = message.Chat.Id;
            List<DayOfWeek> list = new List<DayOfWeek>();
            list.Add(DayOfWeek.Monday);
            list.Add(DayOfWeek.Tuesday);
            list.Add(DayOfWeek.Wednesday);
            list.Add(DayOfWeek.Thursday);
            list.Add(DayOfWeek.Friday);

            for (int i = 0; i < list.Count; i++)
            {
                WorkingDay day = DefineDate.GetDay(DateTime.Now, list[i], i, message.From.Username, message.From.LastName, message.From.FirstName);
                botClient.SendTextMessageAsync(chatId, $"{message.Chat.FirstName}, ваш розклад:\n{list[i]}\n{day.GetSchedule()}");
                Thread.Sleep(1000);
            }
        }
    }
}