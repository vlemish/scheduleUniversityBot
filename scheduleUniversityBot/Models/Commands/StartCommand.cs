using scheduleUniversityBot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
namespace scheduleUniversityBot_net.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";


        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override void Execute(Message message, TelegramBotClient botClient)
        {
           ReplyKeyboardMarkup ReplyKeyboard = new[]
                    {
                        new[] {"/schedule", "/tomorrow", },
                        new[] { "/week",},
                        
                    };
            

            var chatId = message.Chat.Id;

            botClient.SendTextMessageAsync(chatId, "<Hello, friend>\t",replyMarkup:ReplyKeyboard);
          
            
        }
    }
}
