using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using scheduleUniversityBot.Models.Commands;
using scheduleUniversityBot_net.Models.Commands.Days;
using scheduleUniversityBot.Repos;

namespace scheduleUniversityBot_net.Models.Commands
{
    public class TodaySchedule : Command
    {
        public override string Name => @"/schedule";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }
            return message.Text.Contains(this.Name);
        }

        public override void  Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            WorkingDay day = DefineDate.GetDay(DateTime.Now);
            var monday = ScheduleRepos.MondaySchedule();
            botClient.SendTextMessageAsync(chatId, $"{message.Chat.FirstName}, ваш розклад:\n{ day.GetSchedule()}"); 

        }
    }
}

