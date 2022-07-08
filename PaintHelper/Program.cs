using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using GregsStack.InputSimulatorStandard;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using GregsStack.InputSimulatorStandard.Native;
using WindowScrape.Types;

namespace PaintHelper
{
    class Program
    {
        public static InputSimulator simulator = new InputSimulator();
        [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);
		public static void Main(string[] args)
		{
			Console.WindowHeight = 1;
			Console.WindowWidth = 1;

			foreach (var process in Process.GetProcessesByName("mspaint"))
			{
				process.Kill();
			}

			Thread.Sleep(1000);

			if ((from x in Process.GetProcesses()
				 where x.ProcessName.Contains("mspaint")
				 select x).Count() == 0)
			{
				ProcessStartInfo paintProcess = new ProcessStartInfo
				{
					FileName = "mspaint.exe",
					WindowStyle = ProcessWindowStyle.Minimized
				};
				Process.Start(paintProcess);
			}
			int trycounter = 0;
			while (true)
			{
				simulator.Keyboard.KeyPress(VirtualKeyCode.SNAPSHOT);
				Thread.Sleep(1000);
				try
				{
					Bitmap imageFromClipboard = (Bitmap)Clipboard.GetImage();
				}
				catch
				{
					if (trycounter == 5)
					{
						throw new Exception();
					}
					trycounter++;
					continue;
				}
				break;
			}
			ShowWindow(HwndObject.GetWindowByTitle("Untitled - Paint").Hwnd, 9);
			simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
			Thread.Sleep(150);
			Point position = default(Point);
			position.X = 334;
			position.Y = 68;
			Cursor.Position = position;
			Thread.Sleep(150);
			simulator.Mouse.LeftButtonClick();
		}
	}
}
