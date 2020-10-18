using scheduleDbLayer.Repos;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using telegramBotASP.Models;

namespace scheduleBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";


        public override bool Contains(Message message)
        {
            return message.Text.Equals(this.Name);
        }

        public override void Execute(Message message, TelegramBotClient botClient)
        {

            var isRegistrated = new StudentRepo().GetOne(message.From.Username, message.From.LastName, message.From.FirstName) != null;

            var chatId = message.Chat.Id;

            if (isRegistrated)
            {
                botClient.SendTextMessageAsync(chatId, $"{message.From.FirstName}, it looks like you're already registrated... {char.ConvertFromUtf32(0x1F609)}");
            }

            else
            {
                var faculties = new FacultyRepo().GetAll().Select(f=> f.FacultyName).ToList();

                var builder = InlineKeyboardBuilder.Create();

                builder.AddRow();

                foreach (var faculty in faculties)
                {
                    if (faculties.IndexOf(faculty) % 3 == 0)
                    {
                        builder.EndRow();
                        builder.AddRow();
                    }

                    builder.AddButton(faculty, faculty);
                }

                botClient.SendTextMessageAsync(chatId, $"Hello, friend {char.ConvertFromUtf32(0x1F603)}! Choose your faculty:", replyMarkup: builder.Build());
            }



        }
    }
}
