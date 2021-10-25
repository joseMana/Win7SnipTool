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
        public static int pauseTimeTempHolder = 0;
        public static bool initializedNewThread = false;
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
                            Debug.WriteLine("Entering if (shouldPause)");

                            DateTime startTime = DateTime.Now;
                            initializedNewThread = true;
                            while ((DateTime.Now - startTime).Seconds < pauseTime)
                            {
                                Debug.WriteLine("still looping through the datetime.now -starttime");
                                Debug.WriteLine($"pausetime value is {pauseTime}");
                                Debug.WriteLine($"{(DateTime.Now - startTime).Seconds} < {pauseTime}");
                                Thread.Sleep(500);
                            }
                            shouldPause = false;
                            initializedNewThread = false;
                            pauseTime = int.Parse(ConfigurationManager.AppSettings["pauseTime"]);
                            Debug.WriteLine("Ending the Loop, set should = false, initializedNewThread = false, pauseTime = int.Parse(ConfigurationManager.AppSettings)");
                        }
                    }).Start();
                }
                else
                {
                    if (initializedNewThread)
                    {
                        Debug.WriteLine("Entering if (initializedNewThread)");
                        Debug.WriteLine("Adding value to pausetime");
                        pauseTimeTempHolder = pauseTimeTempHolder + 100;

                        if(pauseTimeTempHolder == 1000)
                        {
                            pauseTime++;
                            pauseTimeTempHolder = 0;
                        }

                        Debug.WriteLine($"new value of pausetime {pauseTime}");
                    }
                    else
                    {
                        Debug.WriteLine("Did not enter if (initializedNewThread)");
                    }
                }
            };

        }
    }
}
