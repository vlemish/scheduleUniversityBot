using Telegram.Bot;
using Telegram.Bot.Types;

namespace scheduleUniversityBot_net.Models.Buttons
{
    public abstract class Button
    {
        public abstract string Name { get; }
        public abstract string Data { get; }

        public abstract void Execute(CallbackQuery query, TelegramBotClient botClient);

        public abstract bool Contains(Update message);
    }
}