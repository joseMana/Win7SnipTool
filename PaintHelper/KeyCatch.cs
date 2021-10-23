using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading;
using Gma.System.MouseKeyHook;
using GregsStack.InputSimulatorStandard;
using System.Configuration;

namespace PaintHelper
{
    internal partial class KeyCatch
    {
        
        public static char lastCharPressed { get; set; }
        public static bool shouldPause = false;
        public static int pauseTime = int.Parse(ConfigurationManager.AppSettings["pauseTime"]);
        public static void Start(Action quit)
        {
            var currentPosition = Cursor.Position;

            Hook.GlobalEvents().KeyPress += (sender, e) =>
            {
                if (e.KeyChar == '0')
                {
                    Application.Exit();
                }
                if (!shouldPause)
                {
                    currentPosition = Cursor.Position;
                    Cursor.Position = textInputPosition;
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                    simulator.Mouse.LeftButtonClick();
                    shouldPause = true;
                    new Thread(() =>
                    {
                        if (shouldPause)
                        {
                            DateTime startTime = DateTime.Now;
                            while ((DateTime.Now - startTime).Seconds < pauseTime)
                            {

                            }
                            shouldPause = false;
                        }
                    }).Start();
                }
            };

        }
    }
}
