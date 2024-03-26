using GregsStack.InputSimulatorStandard;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace PaintHelper
{
    class Program
    {
        public static InputSimulator simulator = new InputSimulator();
        static void Main(string[] args)
        {
            string methodName = args[0];

            Type type = typeof(KeyCatch);
            MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            Action<Action> action = methodInfo.CreateDelegate(typeof(Action<Action>)) as Action<Action>;

            action(Application.Exit);

            Application.Run(new ApplicationContext());
        }
    }
}
