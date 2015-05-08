using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BIT_Functions
{
    public class Windows_function
    {
        long curTime = DateTime.Now.Ticks;
        long preTime = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void Call_Windows()
        {
            System.Threading.Thread.Sleep(600);

                Keysend.KeyDown(Keys.LWin);
                Keysend.KeyUp(Keys.LWin);
        }

        public static void Keyboard_LeftArrow()
        {

            System.Threading.Thread.Sleep(600);

                Keysend.KeyDown(Keys.Left);
                Keysend.KeyUp(Keys.Left);
        }

        public static void Keyboard_RightArrow()
        {
            System.Threading.Thread.Sleep(600);

                Keysend.KeyDown(Keys.Right);
                Keysend.KeyUp(Keys.Right);
        }

        public static void Keyboard_ESC()
        {

            System.Threading.Thread.Sleep(600);
            Keysend.KeyDown(Keys.Escape);
            Keysend.KeyUp(Keys.Escape);
        }

        public static void Keyboard_space()
        {

            System.Threading.Thread.Sleep(600);
            Keysend.KeyDown(Keys.Space);
            Keysend.KeyUp(Keys.Space);
        }

        public static void MouseClick_left()
        {

            System.Threading.Thread.Sleep(600);
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
        }

        public static void MouseClick_right()
        {

            System.Threading.Thread.Sleep(600);
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)X, (uint)Y, 0, 0);
        }
    }
}
