
using scheduleBot.Models.Commands;
using scheduleUniversityBot_net.Models.Commands.Days;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace scheduleUniversityBot_net.Models.Commands
{
    public class TodayCommand : Command
    {
        public override string Name => @"/schedule";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }
            return message.Text.Equals(this.Name);
        }

        public override void Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            WorkingDay day = DefineDate.GetDay(DateTime.Now, message.From.Username, message.From.LastName, message.From.FirstName);
            //var schedule = new ScheduleFacade(message.From.Username, message.From.LastName, message.From.FirstName);
            botClient.SendTextMessageAsync(chatId, $"{message.Chat.FirstName}, ваш розклад:\n{ day.GetSchedule()}");
            //botClient.SendTextMessageAsync(chatId, $"{schedule.GetSchedule(2, DayOfWeek.Monday)}");

        }
    }
}