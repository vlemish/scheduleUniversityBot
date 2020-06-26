using scheduleUniversityBot.Models.Commands;
using scheduleUniversityBot_net.Models.Buttons;
using scheduleUniversityBot_net.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace scheduleUniversityBot.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;
        private static List<Button> buttonsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();
        public static IReadOnlyList<Button> Buttons => buttonsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            commandsList.Add(new TodaySchedule());
            commandsList.Add(new TommorowCommand());
            commandsList.Add(new WeekCoomand());
            commandsList.Add(new SubjectCommand());
            //TODO: Add more commands

            buttonsList = new List<Button>();
            buttonsList.Add(new DevelopingElectricalDevicesButton());
            buttonsList.Add(new SystemAnalysisButton());
            buttonsList.Add(new BasicsOfWorkCareButton());
            buttonsList.Add(new ResearchWorkButton());
            buttonsList.Add(new AutomatedExperimentManagementSystemsButton());
            buttonsList.Add(new FlexibleAutomatedProductionAndRoboticComplexesButton());
            buttonsList.Add(new ComputerControlSystemsButton());
            //TODO: Add more buttons

            botClient = new TelegramBotClient(AppSettings.Key);
            string hook = string.Format(AppSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
