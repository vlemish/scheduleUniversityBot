using scheduleDbLayer.Models;
using scheduleDbLayer.Repos;
using scheduleUniversityBot_net.Models.Buttons;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace telegramBotASP.Models.Buttons
{
    public class GroupsButtons : Button
    {
        public override string Name => throw new NotImplementedException(); // There is a problem. Names and data contained in Db

        public override string Data => throw new NotImplementedException(); // the same

        private GroupRepo _groupsRepo = new GroupRepo();

        public override bool Contains(Update message)
        {

            foreach (var g in _groupsRepo.GetAll())
            {
                if (g.GroupName.Equals(message.CallbackQuery.Data))
                {
                    return true;
                }
            }

            return false;
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {
            var isRegistrated = new StudentRepo().GetOne(query.From.Username, query.From.LastName, query.From.FirstName) != null;

            var chatId = query.Message.Chat.Id;

            if (isRegistrated)
            {
                botClient.SendTextMessageAsync(chatId, $"{query.From.FirstName}, it looks like you're already registrated...");
                return;
            }

            else
            {

                var group = _groupsRepo.GetOne(query.Data);

                Student student = new Student()
                {
                    FirstName = query.From.FirstName,
                    LastName = query.From.LastName,
                    UserName = query.From.Username,
                    GroupId = group.Id,
                    FacultyId = group.FacultyId
                };

                BaseRepo<Student> _studentRepo = new BaseRepo<Student>();
                _studentRepo.Add(student);

                ReplyKeyboardMarkup replyKeyboard = new[]
                        {
                        new[] {"/schedule", "/tomorrow", },
                        new[] { "/week",},

                    };


                botClient.SendTextMessageAsync(chatId, $"<Ok, {query.From.FirstName}. You've been successfully added to my memory!", replyMarkup: replyKeyboard);
                botClient.AnswerCallbackQueryAsync(query.Id, "Ok");
            }
        }
    }
}