using scheduleDbLayer.Repos;
using scheduleUniversityBot_net.Models.Buttons;
using Telegram.Bot;
using Telegram.Bot.Types;
using telegramBotASP.Models.Facades;

namespace telegramBotASP.Models.Buttons
{
    public class SubjectsButton : Button
    {
        private SubjectRepo subjectRepo = new SubjectRepo();

        private int subjectId;

        public override bool Contains(Update message)
        {
            var student = new StudentRepo().GetOne(message.CallbackQuery.From.Username, message.CallbackQuery.From.LastName, message.CallbackQuery.From.FirstName);

            foreach (var s in subjectRepo.GetAllSubjectsAssociatedWithGroup(student.GroupId))
            {
                if (new Abbrevation(s.SubjectName).GetAbbrevation().Equals(message.CallbackQuery.Data))
                {
                    subjectId = s.Id;
                    return true;
                }
            }
            return false;
        }

        public override void Execute(CallbackQuery query, TelegramBotClient botClient)
        {

            var chatId = query.Message.Chat.Id;

            SubjectFacade subjectFacade = new SubjectFacade(query.From.Username, query.From.LastName, query.From.FirstName);

            botClient.SendTextMessageAsync(chatId, subjectFacade.GetSubjects(subjectId));

            botClient.AnswerCallbackQueryAsync(query.Id, "Ok");

        }
    }
}