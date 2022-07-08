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
        [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);
        public static InputSimulator simulator = new InputSimulator();
        public static Point linePosition = new Point { X = 381, Y = 61 };
        public static Point boxPosition = new Point { X = 442, Y = 66 };
        public static Point greenColorPosition = new Point { X = 901, Y = 61 };
        public static Point redColorPosition = new Point { X = 829, Y = 60 };
        public static Point yellowColorPosition = new Point { X = 876, Y = 59 };
        public static Point blueColorPosition = new Point { X = 919, Y = 60 };

        public static Point lineThicknessOptionPosition = new Point { X = 634, Y = 73 };
        public static Point lineThickness1Position = new Point { X = 658, Y = 137 };
        public static Point lineThickness2Position = new Point { X = 656, Y = 176 };
        public static Point lineThickness3Position = new Point { X = 661, Y = 211 };
        public static Point lineThickness4Position = new Point { X = 661, Y = 256 };
        public static Point textInputPosition = new Point { X = 290, Y = 70 };

        public static IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
    }
}
