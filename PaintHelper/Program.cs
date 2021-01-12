using Gma.System.MouseKeyHook;
using GregsStack.InputSimulatorStandard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintHelper
{
    // TODO 1: rename variables
    class Program
    {
        public static InputSimulator simulator = new InputSimulator();
        static void Main(string[] args)
        {
            #region getpos
            ////get pos
            //while (true)
            //{
            //    Console.WriteLine("Place Cursor Position\nPress Enter to Get Position");
            //    Console.ReadLine();
            //    Console.WriteLine("X = " + simulator.Mouse.Position.X.ToString() + ", Y = " + simulator.Mouse.Position.Y.ToString());
            //}
            #endregion

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
            

            ////snipping tool
            //Process snippingToolProcess = new Process();
            //snippingToolProcess.EnableRaisingEvents = true;
            //if (!Environment.Is64BitProcess)
            //{
            //    snippingToolProcess.StartInfo.FileName = "C:\\Windows\\sysnative\\SnippingTool.exe";
            //    snippingToolProcess.Start();
            //}
            //else
            //{
            //    snippingToolProcess.StartInfo.FileName = "C:\\Windows\\system32\\SnippingTool.exe";
            //    snippingToolProcess.Start();
            //}

            var selector = new Dictionary<string, Action<Action>>
            {
                {"1. Log keys", LogKeys.Do}
            };
            Action<Action> action = null;
            action = selector.Where(p => p.Key.StartsWith("1"))
                .Select(p => p.Value).FirstOrDefault();
            action(Application.Exit);

            Application.Run(new ApplicationContext());
        }
    }
    internal class LogKeys
    {
        [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);
        public static InputSimulator simulator = new InputSimulator();
        public static Point linePosition = new Point { X = 355, Y = 59 };
        public static Point boxPosition = new Point { X = 411, Y = 62 };
        public static Point greenColorPosition = new Point { X = 841, Y = 57 };
        public static Point redColorPosition = new Point { X = 778, Y = 61 };
        public static Point yellowColorPosition = new Point { X = 818, Y = 63 };
        public static Point blueColorPosition = new Point { X = 862, Y = 60 };

        public static Point lineThicknessOptionPosition = new Point { X = 594, Y = 70 };
        public static Point lineThickness1Position = new Point { X = 616, Y = 138 };
        public static Point lineThickness2Position = new Point { X = 612, Y = 175 };
        public static Point lineThickness3Position = new Point { X = 625, Y = 214 };
        public static Point lineThickness4Position = new Point { X = 629, Y = 258 };
        public static Point textInputPosition = new Point { X = 270, Y = 69 };

        public static IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
        public static char lastCharPressed { get; set; }

        public static void Do(Action quit)
        {
            var currentPosition = Cursor.Position;

            Hook.GlobalEvents().KeyPress += (sender, e) =>
            {
                currentPosition = Cursor.Position;
                if (e.KeyChar == '`')
                {
                    e.Handled = true;
                    ShowWindow(WindowScrape.Types.HwndObject.GetWindowByTitle("Snipping Tool").Hwnd, 9);
                    //snipping tool

                    Process snippingToolProcess1 = new Process();
                    snippingToolProcess1.EnableRaisingEvents = true;
                    if (!Environment.Is64BitProcess)
                    {
                        snippingToolProcess1.StartInfo.FileName = "C:\\Windows\\sysnative\\SnippingTool.exe";
                        snippingToolProcess1.Start();
                    }
                    else
                    {
                        snippingToolProcess1.StartInfo.FileName = "C:\\Windows\\system32\\SnippingTool.exe";
                        snippingToolProcess1.Start();
                    }
                    while (1 == 1)
                    {
                        if (Process.GetProcesses().Where(z => z.ProcessName.Contains("SnippingTool")).FirstOrDefault().ProcessName.Contains("SnippingTool"))
                            break;

                        continue;
                    }
                    Thread.Sleep(500);
                    var a1 = WindowScrape.Types.HwndObject.GetWindowByTitle("Snipping Tool");
                    var x1 = a1.Location.X + 10;
                    var y1 = a1.Location.Y + 10;
                    Cursor.Position = new Point { X = x1, Y = y1 };
                    simulator.Mouse.LeftButtonClick();

                    simulator.Keyboard.ModifiedKeyStroke(
                        GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.CONTROL,
                        GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.VK_N);

                    Cursor.Position = currentPosition;
                }
                if (e.KeyChar == '5')
                {
                    ShowWindow(handle, 9);
                    ShowWindow(handle, 6);
                    Cursor.Position = linePosition;
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                }
                else if(e.KeyChar == '6')
                {
                    ShowWindow(handle, 9);
                    ShowWindow(handle, 6);
                    Cursor.Position = boxPosition;
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == 'g')
                {
                    ShowWindow(handle, 9);
                    ShowWindow(handle, 6);
                    Cursor.Position = greenColorPosition;
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == 'r')
                {
                    ShowWindow(handle, 9);
                    ShowWindow(handle, 6);
                    Cursor.Position = redColorPosition;
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == 'y')
                {
                    ShowWindow(handle, 9);
                    ShowWindow(handle, 6);
                    Cursor.Position = yellowColorPosition;
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == 'b')
                {
                    ShowWindow(handle, 9);
                    ShowWindow(handle, 6);
                    Cursor.Position = blueColorPosition;
                    simulator.Mouse.LeftButtonClick();
                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == '1')
                {
                    if (lastCharPressed != '1')
                    {
                        ShowWindow(handle, 9);
                        ShowWindow(handle, 6);
                        Cursor.Position = lineThicknessOptionPosition;
                        simulator.Mouse.LeftButtonClick();
                    }
                    else
                    {
                        Cursor.Position = lineThickness1Position;
                        simulator.Mouse.LeftButtonClick();
                    }

                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == '2')
                {
                    if (lastCharPressed != '2')
                    {
                        ShowWindow(handle, 9);
                        ShowWindow(handle, 6);
                        Cursor.Position = lineThicknessOptionPosition;
                        simulator.Mouse.LeftButtonClick();
                    }
                    else
                    {
                        Cursor.Position = lineThickness2Position;
                        simulator.Mouse.LeftButtonClick();
                    }

                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == '3')
                {
                    if (lastCharPressed != '3')
                    {
                        ShowWindow(handle, 9);
                        ShowWindow(handle, 6);
                        Cursor.Position = lineThicknessOptionPosition;
                        simulator.Mouse.LeftButtonClick();
                    }
                    else
                    {
                        Cursor.Position = lineThickness3Position;
                        simulator.Mouse.LeftButtonClick();
                    }

                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == '4')
                {
                    if (lastCharPressed != '4')
                    {
                        ShowWindow(handle, 9);
                        ShowWindow(handle, 6);
                        Cursor.Position = lineThicknessOptionPosition;
                        simulator.Mouse.LeftButtonClick();
                    }
                    else
                    {
                        Cursor.Position = lineThickness4Position;
                        simulator.Mouse.LeftButtonClick();
                    }

                    Cursor.Position = currentPosition;
                }
                else if (e.KeyChar == '8')
                {
                    ShowWindow(handle, 9);
                    ShowWindow(handle, 6);
                    if (lastCharPressed == '8')
                    {
                        Cursor.Position = textInputPosition;
                        simulator.Mouse.LeftButtonClick();

                        Cursor.Position = currentPosition;
                        simulator.Mouse.LeftButtonClick();
                        simulator.Keyboard.TextEntry('*');

                        Cursor.Position = linePosition;
                        simulator.Mouse.LeftButtonClick();
                        Cursor.Position = currentPosition;

                        simulator.Keyboard.KeyPress(GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.LCONTROL);
                    }
                    else
                    {
                        Cursor.Position = textInputPosition;
                        simulator.Mouse.LeftButtonClick();
                        Cursor.Position = currentPosition;
                    }
                }
                else if (e.KeyChar == '/')
                {
                    ShowWindow(handle, 9);
                    ShowWindow(handle, 6);
                    if (lastCharPressed == '/')
                    {
                        Cursor.Position = textInputPosition;
                        simulator.Mouse.LeftButtonClick();

                        Cursor.Position = currentPosition;
                        simulator.Mouse.LeftButtonClick();
                        simulator.Keyboard.TextEntry('?');

                        Cursor.Position = linePosition;
                        simulator.Mouse.LeftButtonClick();
                        Cursor.Position = currentPosition;

                        simulator.Keyboard.KeyPress(GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.LCONTROL);
                    }
                    else
                    {
                        Cursor.Position = textInputPosition;
                        simulator.Mouse.LeftButtonClick();
                        Cursor.Position = currentPosition;
                    }
                }
                else if (e.KeyChar == '0')
                {
                    Application.Exit();
                }
                lastCharPressed = e.KeyChar;
            };



            #region improve/refactor this code block - opens the window of snipping tool and initializes a new snip

            //minimizes the console window
            ShowWindow(handle, 6);

            ShowWindow(WindowScrape.Types.HwndObject.GetWindowByTitle("Snipping Tool").Hwnd, 9);
            //snipping tool

            Process snippingToolProcess = new Process();
            snippingToolProcess.EnableRaisingEvents = true;
            if (!Environment.Is64BitProcess)
            {
                snippingToolProcess.StartInfo.FileName = "C:\\Windows\\sysnative\\SnippingTool.exe";
                snippingToolProcess.Start();
            }
            else
            {
                snippingToolProcess.StartInfo.FileName = "C:\\Windows\\system32\\SnippingTool.exe";
                snippingToolProcess.Start();
            }
            while (1 == 1)
            {
                if (Process.GetProcesses().Where(z => z.ProcessName.Contains("SnippingTool")).FirstOrDefault().ProcessName.Contains("SnippingTool"))
                    break;

                continue;
            }
            Thread.Sleep(500);
            var a = WindowScrape.Types.HwndObject.GetWindowByTitle("Snipping Tool");
            var x = a.Location.X + 10;
            var y = a.Location.Y + 10;
            Cursor.Position = new Point { X = x, Y = y };
            simulator.Mouse.LeftButtonClick();

            simulator.Keyboard.ModifiedKeyStroke(
                GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.CONTROL,
                GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.VK_N);

            Cursor.Position = currentPosition;
            #endregion



            //Hook.GlobalEvents().MouseMoveExt += (sender, e) =>
            //{
            //    new Thread(() =>
            //    {
            //        Console.WriteLine(e.Y);
            //        Thread.Sleep(1000);
            //        if (e.Y < 30)
            //            Cursor.Position = new Point { X = 500, Y = 500 };
            //    }).Start();
            //};
        }
    }
}
