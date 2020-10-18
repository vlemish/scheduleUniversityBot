namespace scheduleUniversityBot_net.Models.Commands.Days
{
    public abstract class WorkingDay
    {
        public bool isEven { get; set; }

        protected string Username { get; set; }

        protected string LastName { get; set; }

        protected string FirstName { get; set; }

        public WorkingDay(bool even, string username, string lastname, string firstname)
        {
            isEven = even;
            Username = username;
            LastName = lastname;
            FirstName = firstname;

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