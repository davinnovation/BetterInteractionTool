using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BIT_Functions
{
    public class Windows_function
    {
        static DateTime curTime = DateTime.Now;
        static DateTime preTime = DateTime.Now;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void call_function(int which)
        {
            switch (which)
            {
                case -1:
                    Console.WriteLine("None Connected");
                    break;
                case 0:
                    this.Keyboard_Copy_the_selected_item();
                    break;
                case 1:
                    this.Keyboard_Cut_the_selected_item();
                    break;
                case 2:
                    this.Keyboard_Paste_the_selected_item();
                    break;
                case 3:
                    this.Keyboard_Switch_open_apps();
                    break;
                case 4:
                    this.Keyboard_Close_the_active_app();
                    break;
                case 5:
                    this.Keyboard_Open_search_charm();
                    break;
                case 6:
                    this.Keyboard_Switch_open_apps();
                    break;
                case 7:
                    this.Keyboard_Delete_the_selected_item();
                    break;
                case 8:
                    this.Keyboard_LeftArrow();
                    break;
                case 9:
                    this.Keyboard_RightArrow();
                    break;
                case 10:
                    this.Keyboard_UpArrow();
                    break;
                case 11:
                    this.Keyboard_DownArrow();
                    break;
                case 12:
                    this.Call_Windows();
                    break;
                case 13:
                    this.Keyboard_ESC();
                    break;
                case 14:
                    this.Keyboard_space();
                    break;
                case 15:
                    this.MouseClick_left();
                    break;
                case 16:
                    this.MouseClick_right();
                    break;
            }
        }

        private bool check_fps()
        {
            preTime = curTime;
            curTime = DateTime.Now;

            TimeSpan check = curTime.Subtract(preTime);

            if (check.TotalMilliseconds > 500)
            {
                System.Threading.Thread.Sleep(200); 
                return true;
            }

            else
                return false;
        }

        public void Call_Windows()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.LWin);
                Keysend.KeyUp(Keys.LWin);
            }
        }

        public void Keyboard_Copy_the_selected_item()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Control);
                Keysend.KeyDown(Keys.C);
                Keysend.KeyUp(Keys.Control);
                Keysend.KeyUp(Keys.C);
            }
        }

        public void Keyboard_Cut_the_selected_item()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Control);
                Keysend.KeyDown(Keys.X);
                Keysend.KeyUp(Keys.Control);
                Keysend.KeyUp(Keys.X);
            }
        }

        public void Keyboard_Paste_the_selected_item()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Control);
                Keysend.KeyDown(Keys.V);
                Keysend.KeyUp(Keys.Control);
                Keysend.KeyUp(Keys.V);
            }
        }

        public void Keyboard_Switch_open_apps()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Alt);
                Keysend.KeyDown(Keys.Tab);
                Keysend.KeyUp(Keys.Alt);
                Keysend.KeyUp(Keys.Tab);
            }
        }

        public void Keyboard_Close_the_active_app()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Alt);
                Keysend.KeyDown(Keys.F4);
                Keysend.KeyUp(Keys.Alt);
                Keysend.KeyUp(Keys.F4);
            }
        }

        public void Keyboard_Open_search_charm()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.LWin);
                Keysend.KeyDown(Keys.F);
                Keysend.KeyUp(Keys.LWin);
                Keysend.KeyUp(Keys.F);
            }
        }

        public void Keyboard_Delete_the_selected_item()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Control);
                Keysend.KeyDown(Keys.D);
                Keysend.KeyUp(Keys.Control);
                Keysend.KeyUp(Keys.D);
            }
        }

        public void Keyboard_LeftArrow()
        {
            if (check_fps())
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

        public void Keyboard_UpArrow()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Up);
                Keysend.KeyUp(Keys.Up);
            }
        }

        public void Keyboard_DownArrow()
        {
            if (check_fps())
            {
                Keysend.KeyDown(Keys.Down);
                Keysend.KeyUp(Keys.Down);
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
