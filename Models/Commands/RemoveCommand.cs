using scheduleBot.Models.Commands;
using scheduleDbLayer.Repos;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace telegramBotASP.Models.Commands
{
    public class RemoveCommand : Command
    {
        public override string Name { get; } = @"/remove";

        public override bool Contains(Message message)
        {
            return message.Text.Equals(this.Name);
        }

        public override void Execute(Message message, TelegramBotClient botClient)
        {
            using (var students = new StudentRepo())
            {
                var chatId = message.Chat.Id;

                var student = students.GetOne(message.From.Username, message.From.LastName, message.From.FirstName);

                if (student == null)
                {
                    botClient.SendTextMessageAsync(chatId, $"I don't know you... {char.ConvertFromUtf32(0x1F614)}");
                    return;
                }

                students.Delete(student);

                botClient.SendTextMessageAsync(chatId, $"You were removed {char.ConvertFromUtf32(0x1F622)}");
                botClient.SendTextMessageAsync(chatId, $"Hope you come back {char.ConvertFromUtf32(0x1F604)}");
            }
        }
    }
}