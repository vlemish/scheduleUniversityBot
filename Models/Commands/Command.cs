﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace scheduleUniversityBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract bool Contains(Message message);

        public abstract void Execute(Message message, TelegramBotClient botClient);

    }
}
