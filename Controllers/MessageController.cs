using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using System.Web.Http;
using System.Web.Http.Results;
using scheduleBot.Models;
using System.EnterpriseServices;
using Telegram.Bot;

namespace scheduleBot.Controllers
{
    [Route(@"api/message/update")] //webhook uri part
    public class MessageController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "It works!";
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody] Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var buttons = Bot.Buttons;

            var message = update.Message;
            var query = update.CallbackQuery;

            var botClient =  Bot.GetBotClientAsync();


            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                foreach (var command in commands)
                {
                    if (command.Contains(message))
                    {
                        command.Execute(message, botClient);
                        return Ok();
                    }
                }

                await botClient.SendTextMessageAsync(message.Chat.Id, $"{message.Text} isn't supported command {char.ConvertFromUtf32(0x1F643)}\n" +
                    $"If you have ideas of features that would be good to add, feel free to write to me: <a>vlad.lemish123@gmail.com</a>"
                    ,Telegram.Bot.Types.Enums.ParseMode.Html);
                return Ok();
            }

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
                foreach (var button in buttons)
                {
                    if (button.Contains(update))
                    {
                        button.Execute(query, botClient);
                        return Ok();
                    }
                }


            return Ok();
        }
    }
}