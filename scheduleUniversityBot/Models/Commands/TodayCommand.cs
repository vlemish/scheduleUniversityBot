
using scheduleBot.Models.Commands;
using scheduleDbLayer.Repos;
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
            var student = new StudentRepo().GetOne(message.From.Username, message.From.LastName, message.From.FirstName);

            var isRegistrated = student != null;

            var chatId = message.Chat.Id;

            if (!isRegistrated)
            {
                botClient.SendTextMessageAsync(chatId, $"You aren't registered, please call /start command to start working with bot.");
            }

            else
            {
                WorkingDay day = DefineDate.GetDay(DateTime.Now, message.From.Username, message.From.LastName, message.From.FirstName);
                botClient.SendTextMessageAsync(chatId, $"{message.Chat.FirstName}, ваш розклад:\n{ day.GetSchedule()}");
            }
        }
    }
}