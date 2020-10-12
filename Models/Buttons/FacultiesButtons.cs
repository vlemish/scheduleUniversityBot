using scheduleDbLayer.Models;
using scheduleDbLayer.Repos;
using scheduleUniversityBot_net.Models.Buttons;
using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace telegramBotASP.Models.Buttons
{
    public class FacultiesButton : Button
    {

        private BaseRepo<Faculty> _facultiesRepo = new BaseRepo<Faculty>();

        private int facultyId; // to store chose faculty

        public override bool Contains(Update message)
        {
            foreach (var f in _facultiesRepo.GetAll())
            {
                if (f.FacultyName.Equals(message.CallbackQuery.Data))
                {
                    facultyId = f.Id;
                    return true;
                }
            }
            return false;
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {

            var groups = new GroupRepo().GetAll(facultyId); // to get groups from specific faculty


            var inlineKeyboard = new InlineKeyboardMarkup(new[]
                {
                    groups.Select(g=> InlineKeyboardButton.WithCallbackData($"{g.GroupName}",$"{g.GroupName}"))

                });


            var chatId = query.Message.Chat.Id;

            botClient.SendTextMessageAsync(chatId, "<Ok, choose the group you're studying in>\t", replyMarkup: inlineKeyboard);

            botClient.AnswerCallbackQueryAsync(query.Id, "Ok");

        }
    }
}