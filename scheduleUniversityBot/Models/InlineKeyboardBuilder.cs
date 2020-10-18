using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types.ReplyMarkups;

namespace telegramBotASP.Models
{
    public class InlineKeyboardBuilder
    {
        private List<List<InlineKeyboardButton>> keyboard = new List<List<InlineKeyboardButton>>();
        private List<InlineKeyboardButton> row = null;

        private InlineKeyboardBuilder() { }

        public static InlineKeyboardBuilder Create()
        {
            InlineKeyboardBuilder builder = new InlineKeyboardBuilder();
            return builder;
        }


        public InlineKeyboardBuilder AddRow()
        {
            this.row = new List<InlineKeyboardButton>();
            return this;
        }

        public InlineKeyboardBuilder AddButton(string text, string callbackData)
        {
            this.row.Add(new InlineKeyboardButton()
            {
                Text = text,
                CallbackData = callbackData,
            });

            return this;
        }

        public InlineKeyboardBuilder EndRow()
        {
            this.keyboard.Add(this.row);
            this.row = null;

            return this;
        }


        public InlineKeyboardMarkup Build()
        {
            if (this.row != null)
            {
                this.EndRow();
            }

            return new InlineKeyboardMarkup(this.keyboard);
        }
    }
}