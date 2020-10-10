using Telegram.Bot;
using Telegram.Bot.Types;

namespace scheduleBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract bool Contains(Message message);

        public abstract void Execute(Message message, TelegramBotClient botClient);
    }
}
