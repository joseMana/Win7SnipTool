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

        public static void Start(Action quit)
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
                else if (e.KeyChar == '6')
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

            Initialize(currentPosition);
        }

        private static void Initialize(Point currentPosition)
        {
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
        }
    }

}
