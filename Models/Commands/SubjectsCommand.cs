using scheduleBot.Models.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace scheduleUniversityBot_net.Models.Commands
{
    public class SubjectsCommand : Command
    {
        public override string Name { get; } = @"/subjects";

        public override bool Contains(Message message)
        {
            return message.Equals(this.Name);
        }

        public override void Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;


        }
    }
}