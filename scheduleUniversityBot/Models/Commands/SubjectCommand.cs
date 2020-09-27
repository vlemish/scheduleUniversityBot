using scheduleUniversityBot.Controllers;
using scheduleUniversityBot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace scheduleUniversityBot_net.Models.Commands
{
    public class SubjectCommand : Command
    {
        public override string Name => @"/info";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override void Execute(Message message, TelegramBotClient botClient)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
{
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Конструирование электронных устройств","1"),
                        InlineKeyboardButton.WithCallbackData("Системний аналіз","2"),
                        InlineKeyboardButton.WithCallbackData("Основи охорони праці","3"),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Науково-дослідницька робота","4"),
                        InlineKeyboardButton.WithCallbackData("Автоматизовані системи керування експериментом","5"),
                        InlineKeyboardButton.WithCallbackData("Гнучке автоматизоване виробництво і робото-технічні комплекси","6"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Комп''ютерні системи управління","7"),
                    },
                });

            botClient.SendTextMessageAsync(message.Chat.Id, "Обери: ",replyMarkup:inlineKeyboard);
        }

    }   
}
