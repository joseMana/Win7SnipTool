using Gma.System.MouseKeyHook;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PaintHelper
{
    internal partial class KeyCatch
    {
        public static char lastCharPressed { get; set; }
        public static bool shouldPause = false;
        public static int pauseTime = int.Parse(ConfigurationManager.AppSettings["pauseTime"]);
        public static int pauseTimeTempHolder = 0;
        public static bool initializedNewThread = false;
        public static void PaintWriter(Action quit)
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
                    Thread.Sleep(10);
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                    simulator.Mouse.LeftButtonClick();
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
        public static void GetCursorPosition(Action quit)
        {
            Hook.GlobalEvents().MouseClick += (sender, e) =>
            {
                var currentPosition = Cursor.Position;

                Console.WriteLine($"Cursor.Position = new Point({currentPosition.X}, {currentPosition.Y});");
            };
        }
        public static void GetCursorPositionUsingTab(Action quit)
        {
            Hook.GlobalEvents().KeyPress += (sender, e) =>
            {
                if(e.KeyChar == '\t') 
                { 
                    var currentPosition = Cursor.Position;
                    Console.WriteLine($"Cursor.Position = new Point({currentPosition.X}, {currentPosition.Y});");
                }

            };
        }
        private static string stepName = "removeRef";
        private static int uploadCounter = 0;
        public static void StartFFAut(Action quit)
        {
            string step() {
                string returnStepName = string.Empty;
                if (stepName == "removeRef")
                {
                    stepName = "uploadRef";
                    returnStepName = "removeRef";
                }
                else if (stepName == "uploadRef")
                {
                    stepName = "download";
                    returnStepName = "removeRef";

                }
                else if (stepName == "download")
                {
                    stepName = "uploadRef";
                    returnStepName = "download";
                }
                return returnStepName;
            };

            Hook.GlobalEvents().MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (step() == "removeRef")
                    {
                        Cursor.Position = new Point(836, 686);
                        Thread.Sleep(750);
                        Program.simulator.Mouse.LeftButtonClick();
                    }
                    else if (step() == "uploadRef")
                    {
                        Cursor.Position = new Point(838, 666);
                        Thread.Sleep(750);
                        Program.simulator.Mouse.LeftButtonClick();

                        Thread.Sleep(750);
                        Cursor.Position = new Point(574, 411);
                        Program.simulator.Mouse.LeftButtonClick();

                        Thread.Sleep(750);
                        for (int i = 0; i < uploadCounter; i++)
                        {
                            Program.simulator.Keyboard.KeyPress(GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.RIGHT);
                            Thread.Sleep(100);
                        }
                        Program.simulator.Keyboard.KeyPress(GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.RETURN);
                    }
                    else if (step() == "download")
                    {

                        Cursor.Position = new Point(1423, 149);
                    }
                }
            };
        }
        private static int CorrectInputCount = 0;
        public static void ScreenFreezer(Action quit)
        {
            Hook.GlobalEvents().MouseMove += (sender, e) =>
            {
                Cursor.Position = new Point(0, 0);
            };


            Hook.GlobalEvents().KeyPress += (sender, e) =>
            {
                if (e.KeyChar == '0')
                {
                    CorrectInputCount++;
                }
                else
                {
                    CorrectInputCount = 0;
                }
            };
        }
    }
}
