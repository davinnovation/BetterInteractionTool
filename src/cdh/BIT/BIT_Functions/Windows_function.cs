using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BIT_Functions
{
    public class Windows_function
    {
        DateTime curTime;
        DateTime preTime;
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Windows_function()
        {
            curTime = DateTime.Now;
            preTime = DateTime.Now;
        }

        private bool check_fps()
        {
            System.Threading.Thread.Sleep(600);
            preTime = curTime;
            curTime = DateTime.Now;

            TimeSpan check = curTime.Subtract(preTime);

            if(check.Milliseconds > 500)
                return true;

            else 
                return false;
        }

        public void Call_Windows()
        {
            if ( check_fps() )
            {
                Keysend.KeyDown(Keys.LWin);
                Keysend.KeyUp(Keys.LWin);
            }
        }

        public void Keyboard_LeftArrow()
        {
            if ( check_fps() )
            {
                Keysend.KeyDown(Keys.Left);
                Keysend.KeyUp(Keys.Left);
            }
        }

        public void Keyboard_RightArrow()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Right);
                Keysend.KeyUp(Keys.Right);
            }
        }

        public void Keyboard_ESC()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Escape);
                Keysend.KeyUp(Keys.Escape);
            }
        }

        public void Keyboard_space()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Space);
                Keysend.KeyUp(Keys.Space);
            }
        }

        public void MouseClick_left()
        {
            if (check_fps())
            {
                int X = Cursor.Position.X;
                int Y = Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
        }

        public void MouseClick_right()
        {
            if (check_fps())
            {
                int X = Cursor.Position.X;
                int Y = Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)X, (uint)Y, 0, 0);
            }
        }
    }
}
