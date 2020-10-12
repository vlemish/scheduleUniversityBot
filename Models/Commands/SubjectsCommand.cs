using scheduleBot.Models.Commands;
using scheduleDbLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace telegramBotASP.Models.Commands
{
    public class SubjectsCommand : Command
    {
        public override string Name => @"/subjects";

        public override bool Contains(Message message)
        {
            return message.Text.Equals(this.Name);
        }

        public override void Execute(Message message, TelegramBotClient botClient)
        {
            var student = new StudentRepo().GetOne(message.From.Username, message.From.LastName, message.From.FirstName);
            
            var isRegistrated = student != null;

            var chatId = message.Chat.Id;

            if (!isRegistrated)
            {
                botClient.SendTextMessageAsync(chatId, $"{message.From.FirstName}, it looks like you're already registrated... {char.ConvertFromUtf32(0x1F609)}");
            }

            else
            {

                var builder = InlineKeyboardBuilder.Create();
                var subjects = new SubjectRepo().GetAllSubjectsAssociatedWithGroup(student.GroupId).Select(s => s.SubjectName).ToList();

                builder.AddRow();
                foreach (var subject in subjects)
                {
                    if (subjects.IndexOf(subject) % 3 == 0)
                    {
                        builder.EndRow();
                        builder.AddRow();
                    }

                    builder.AddButton(subject, new Abbrevation(subject).GetAbbrevation());
                }

                botClient.SendTextMessageAsync(chatId, "Here is your subjects:", replyMarkup:builder.Build());

            }
            
        }
    }
}