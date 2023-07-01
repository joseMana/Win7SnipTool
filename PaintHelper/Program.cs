using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Reminder> reminders = new List<Reminder>
            {
                new Reminder()
                    .SetYear(2023)
                    .SetMonth(7)
                    .SetDay(3)
                    .SetTime(20, 30, 0)
                    .SetMessage("IT WWORKS"),

                new Reminder()
                    .SetYear(2023)
                    .SetMonth(7)
                    .SetDay(7)
                    .SetTime(22, 30, 0)
                    .SetMessage("ASK MAMA ABOUT INSURANCE"),

                new Reminder()
                    .SetYear(2023)
                    .SetMonth(7).SetDay(3)
                    .SetTime(22, 30, 0)
                    .SetMessage("REMEMBER TO GET A CAR WASH")
            };

            Reminders reminderManager = new Reminders(reminders);

            // Enter a loop to continuously check the date and time
            while (true)
            {
                reminderManager.CheckReminders();

                Task.Delay(TimeSpan.FromMinutes(1)).Wait();
            }
        }
    }

    class Reminder
    {
        private DateTime dateTime;
        public string Message { get; private set; }

        public Reminder SetYear(int year)
        {
            dateTime = new DateTime(year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            return this;
        }

        public Reminder SetMonth(int month)
        {
            dateTime = new DateTime(dateTime.Year, month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            return this;
        }

        public Reminder SetDay(int day)
        {
            dateTime = new DateTime(dateTime.Year, dateTime.Month, day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            return this;
        }

        public Reminder SetTime(int hour, int minute, int second)
        {
            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, second);
            return this;
        }

        public Reminder SetMessage(string message)
        {
            Message = message;
            return this;
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }
    }

    class Reminders
    {
        private List<Reminder> reminders;

        public Reminders(List<Reminder> reminders)
        {
            this.reminders = reminders;
        }

        public void CheckReminders()
        {
            DateTime now = DateTime.Now;

            foreach (Reminder reminder in reminders)
            {
                if (now >= reminder.GetDateTime())
                {
                    PlayAlertSound();
                    MessageBox.Show(reminder.Message);
                }
            }
        }
        private void PlayAlertSound()
        {
            for (int i = 0; i < 3; i++) // Play the alert sound three times
            {
                SystemSounds.Exclamation.Play();
                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            }
        }
    }
}
