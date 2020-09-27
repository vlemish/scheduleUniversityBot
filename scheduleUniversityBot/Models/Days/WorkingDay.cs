using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
namespace scheduleUniversityBot_net.Models.Commands.Days
{
    public abstract class WorkingDay
    {
        public bool isEven { get; set; }
        public WorkingDay(bool even)
        {
            isEven = even;
            
        }

        protected abstract string GetEvenSchedule();

        protected abstract string GetOddSchedule();

        
        public virtual string GetSchedule()
        {
            if (isEven)
            {
                return GetEvenSchedule();
            }
            else return GetOddSchedule();
        }
    }
    }
            
    
