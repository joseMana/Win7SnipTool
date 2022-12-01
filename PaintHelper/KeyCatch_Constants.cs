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
        public static Point textInputPosition = new Point { X = 270 + 97, Y = 69 + 35 };

        public static IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
    }
}
