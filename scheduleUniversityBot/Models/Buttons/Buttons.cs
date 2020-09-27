using scheduleUniversityBot.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace scheduleUniversityBot_net.Models.Buttons
{
    public class DevelopingElectricalDevicesButton : Button
    {
        public override string Name => "Конструирование электронных устройств";

        public override string Data => "1";

        public override bool Contains(Update update)
        {
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
                return false;

            return update.CallbackQuery.Data==Data;
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {
            var chatId = query.Message.Chat.Id;
            var subject = SubjectRepos.GetSubjectInfo(Name);
            botClient.SendTextMessageAsync(chatId, subject);
            botClient.AnswerCallbackQueryAsync(query.Id, "");
            
        }
    }
    public class SystemAnalysisButton : Button
    {
        public override string Name => "Системний аналіз";

        public override string Data => "2";

        public override bool Contains(Update update)
        {
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                return false;
            }
            return update.CallbackQuery.Data.Contains(Data);
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {
            var chatId = query.Message.Chat.Id;
            var subject = SubjectRepos.GetSubjectInfo(Name);
            botClient.SendTextMessageAsync(chatId, subject);
            botClient.AnswerCallbackQueryAsync(query.Id, "");

        }
    }
    public class BasicsOfWorkCareButton : Button
    {
        public override string Name => "Основи охорони праці";

        public override string Data => "3";

        public override bool Contains(Update update)
        {
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                return false;
            }
            return update.CallbackQuery.Data.Contains(Data);
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {
            var chatId = query.Message.Chat.Id;
            var subject = SubjectRepos.GetSubjectInfo(Name);
            botClient.SendTextMessageAsync(chatId, subject);
            botClient.AnswerCallbackQueryAsync(query.Id, "");

        }
    }
    public class ResearchWorkButton : Button
    {
        public override string Name => "Науково-дослідницька робота";

        public override string Data => "4";

        public override bool Contains(Update update)
        {
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                return false;
            }
            return update.CallbackQuery.Data.Contains(Data);
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {
            var chatId = query.Message.Chat.Id;
            var subject = SubjectRepos.GetSubjectInfo(Name);
            botClient.SendTextMessageAsync(chatId, subject);
            botClient.AnswerCallbackQueryAsync(query.Id, "");

        }
    }
    public class AutomatedExperimentManagementSystemsButton : Button
    {
        public override string Name => "Автоматизовані системи керування експериментом";

        public override string Data => "5";

        public override bool Contains(Update update)
        {
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                return false;
            }
            return update.CallbackQuery.Data.Contains(Data);
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {
            var chatId = query.Message.Chat.Id;
            var subject = SubjectRepos.GetSubjectInfo(Name);
            botClient.SendTextMessageAsync(chatId, subject);
            botClient.AnswerCallbackQueryAsync(query.Id, "");

        }
    }
    public class FlexibleAutomatedProductionAndRoboticComplexesButton : Button
    {
        public override string Name => "Гнучке автоматизоване виробництво і робото-технічні комплекси";

        public override string Data => "6";

        public override bool Contains(Update update)
        {
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                return false;
            }
            return update.CallbackQuery.Data.Contains(Data);
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {
            var chatId = query.Message.Chat.Id;
            var subject = SubjectRepos.GetSubjectInfo(Name);
            botClient.SendTextMessageAsync(chatId, subject);
            botClient.AnswerCallbackQueryAsync(query.Id, "");

        }
    }

    public class ComputerControlSystemsButton : Button
    {

        public override string Name => "Комп''ютерні системи управління";

        public override string Data => "7";

        public override bool Contains(Update update)
        {
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                return false;
            }
            return update.CallbackQuery.Data.Contains(Data);
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {
            var chatId = query.Message.Chat.Id;
            var subject = SubjectRepos.GetSubjectInfo(Name);
            botClient.SendTextMessageAsync(chatId, subject);
            botClient.AnswerCallbackQueryAsync(query.Id, "");

        }
    }
}