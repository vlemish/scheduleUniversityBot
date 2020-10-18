using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telegramBotASP.Models
{
    public class Abbrevation
    {
        public string Text { get; set; }

        private int countForOdd = 3;
        private int countForEven = 4;
        private int minLength = 8;

        public Abbrevation(string text)
        {
            Text = text;
        }

        public string GetAbbrevation()
        {
            var splittedText = Text.Split(' ');
            var output = "";

            foreach (var text in splittedText)
            {
                if (text.Length > minLength)
                {
                    if (text.Length % 2 == 0)
                    {
                        output += text.Substring(0, countForEven) + ". ";
                    }
                    else if (text.Length % 2 != 0)
                    {
                        output += text.Substring(0, countForOdd) + ". ";
                    }
                }
                else output += text + " ";
            }

            return output.Trim();
        }
    }
}