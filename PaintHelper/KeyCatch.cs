using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading;
using Gma.System.MouseKeyHook;
using GregsStack.InputSimulatorStandard;

namespace PaintHelper
{
    internal partial class KeyCatch
    {
        
        public static char lastCharPressed { get; set; }
        public static bool shouldPause = false;
        public static void Start(Action quit)
        {
            var currentPosition = Cursor.Position;
            new Thread(() =>
            {
                while(1 == 1)
                {
                    if (shouldPause)
                    {
                        DateTime startTime = DateTime.Now;
                        while ((DateTime.Now - startTime).Seconds < 6)
                        {
                            
                        }
                        shouldPause = false;
                    }

                    Thread.Sleep(1000);
                }
            }).Start();
            Hook.GlobalEvents().KeyPress += (sender, e) =>
            {
                if (!shouldPause)
                {
                    currentPosition = Cursor.Position;
                    Cursor.Position = textInputPosition;
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                    simulator.Mouse.LeftButtonClick();
                    shouldPause = true;
                }
                if (e.KeyChar == '0')
                {
                    Application.Exit();
                }
            };

        }
    }
}
