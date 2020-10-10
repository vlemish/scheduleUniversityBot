using scheduleBot.Models.Commands;
using scheduleUniversityBot_net.Models.Buttons;
using scheduleUniversityBot_net.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Telegram.Bot;
using telegramBotASP.Models.Buttons;
using telegramBotASP.Models.Commands;

namespace scheduleBot.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;
        private static List<Button> buttonsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();
        public static IReadOnlyList<Button> Buttons => buttonsList.AsReadOnly();

        public static TelegramBotClient GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            commandsList.Add(new RemoveCommand());
            commandsList.Add(new TodayCommand());
            commandsList.Add(new TommorowCommand());
            commandsList.Add(new WeekCoomand());
            //commandsList.Add(new SubjectCommand());
            //TODO: Add more commands

            buttonsList = new List<Button>();
            buttonsList.Add(new FacultiesButton());
            buttonsList.Add(new GroupsButtons());
            //TODO: Add more buttons

            botClient = new TelegramBotClient(AppSettings.Key);
            string hook = string.Format(AppSettings.Url, "api/message/update");
            botClient.SetWebhookAsync(hook);
            return botClient;
        }

//        /start - Start working with bot
//        /schedule - Returns today schedule
//        /tomorrow - Returns tomorrow schedule
//        /week - Returns weekly schedule
//        /remove - Removes you from bot's memory(Can be used to re-register).
    }
}
