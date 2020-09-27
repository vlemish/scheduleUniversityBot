using scheduleUniversityBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;

namespace scheduleUniversityBot.Controllers
{

    public class MessageController : ApiController
    {
        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody] Update update)
        {

            if (update == null) return Ok();
            var commands = Bot.Commands;
            var buttons = Bot.Buttons;

            var message = update.Message;
            var query = update.CallbackQuery;

            var botClient = await Bot.GetBotClientAsync();


            foreach (var button in buttons)
            {
                if (button.Contains(update))
                {
                    button.Execute(query, botClient);
                    return Ok();
                }
            }

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    command.Execute(message, botClient);
                    return Ok();
                }

            }
            return Ok();
        }

    }
}
