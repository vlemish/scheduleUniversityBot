using scheduleDbLayer.Repos;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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

                var faculties = new FacultyRepo().GetAll();

                var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                    faculties.Select(f=> InlineKeyboardButton.WithCallbackData($"{f.FacultyName}",$"{f.FacultyName}"))
                });

                //var inlineKeyboard = new InlineKeyboardMarkup(new[]
                //    {
                //        // first row
                //        new []
                //        {
                //            InlineKeyboardButton.WithCallbackData("Mechanical","1"),
                //            InlineKeyboardButton.WithCallbackData("Automobile","2"),
                //        },
                //    });


                botClient.SendTextMessageAsync(chatId, $"Hello, friend {char.ConvertFromUtf32(0x1F603)}! Choose your faculty:", replyMarkup: inlineKeyboard);
            }



        }
    }
}
