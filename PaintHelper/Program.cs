using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using GregsStack.InputSimulatorStandard;
using System.Drawing;
using System.Threading;

namespace PaintHelper
{
    class Program
    {
        public static InputSimulator simulator = new InputSimulator();
        static void Main(string[] args)
        {
            Console.WindowHeight = 1;
            Console.WindowWidth = 1;

            if (Process.GetProcesses().Where(x => x.ProcessName.Contains("mspaint")).Count() == 1)
            {
                //paint
                ProcessStartInfo paintProcess = new ProcessStartInfo()
                {
                    FileName = "mspaint.exe",
                    WindowStyle = ProcessWindowStyle.Minimized
                };
                Process.Start(paintProcess);
            }

            #region Screenshot
            Bitmap imageFromClipboard;
            int trycounter = 0;
            while (true)
            {
                Program.simulator.Keyboard.KeyPress(GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.MBUTTON | GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.DOWN);
                Thread.Sleep(1000);
                try
                {
                    imageFromClipboard = (Bitmap)Clipboard.GetImage(); break;
                }
                catch
                {
                    if (trycounter == 5)
                        throw new Exception();

                    trycounter++;
                    continue;
                }
            }
            #endregion

        }
    }
}
