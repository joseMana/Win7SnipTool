using System;
using System.Media;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // set the target time for the MessageBox
            TimeSpan targetTime = new TimeSpan(22, 55, 0); // 10:55pm

            // enter an infinite loop to check the time and execute the statement at the right time
            while (true)
            {
                // get the current date and time
                DateTime now = DateTime.Now;

                // check if the current time is after the target time for today, and before midnight
                if (now.TimeOfDay >= targetTime && now.TimeOfDay < TimeSpan.FromHours(24))
                {
                    // display a MessageBox with the message
                    MessageBox.Show("PREPARE FOR DSU!!!!");

                    SystemSounds.Exclamation.Play();
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                    SystemSounds.Exclamation.Play();
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                    SystemSounds.Exclamation.Play();

                    // wait for the next day
                    DateTime tomorrow = now.AddDays(1).Date + targetTime;
                    TimeSpan timeToWait = tomorrow - now;
                    System.Threading.Thread.Sleep(timeToWait);
                }
                else
                {
                    // wait for a minute before checking again
                    System.Threading.Thread.Sleep(TimeSpan.FromMinutes(1));
                }
            }
        }
    }
}