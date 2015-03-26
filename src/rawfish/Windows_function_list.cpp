/*
 * Coded by : Davi Innovation 
 * 
 * list by : Microsoft - http://windows.microsoft.com/en-us/windows/keyboard-shortcuts#keyboard-shortcuts=windows-8
 */

using System.Windows.Forms;

namespace WindowsFunctions
{
    class Windows_function_list
    {
        bool Switch_between_open_apps()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.LWin);
                Get_keyboard.KeyDown(Keys.Tab);
                Get_keyboard.KeyUp(Keys.LWin);
                Get_keyboard.KeyUp(Keys.Tab);
            }
            catch
            {
                test = false;
            }
            return test;
        }
        bool Back()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Alt);
                Get_keyboard.KeyDown(Keys.Left);
                Get_keyboard.KeyUp(Keys.Alt);
                Get_keyboard.KeyUp(Keys.Left);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        /* Coded by rawfish from here
         If Ctrl doesn't work, try Key.ControlKey instead of Key.Control*/

        bool Close_active()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.F4);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.F4);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_all_items()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.A);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.A);

            }
            catch
            {
                test = false;
            }
            return test;
        }


        bool Delete_selected()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.D);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.D);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Refresh_active()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.R);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.R);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Redo_action()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Y);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Y);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_multiple_item_up()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Space);
                Get_keyboard.KeyDown(Keys.Up);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Space);
                Get_keyboard.KeyUp(Keys.Up);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_multiple_item_down()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Space);
                Get_keyboard.KeyDown(Keys.Down);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Space);
                Get_keyboard.KeyUp(Keys.Down);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_multiple_item_left()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Space);
                Get_keyboard.KeyDown(Keys.Left);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Space);
                Get_keyboard.KeyUp(Keys.Left);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_multiple_item_right()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Space);
                Get_keyboard.KeyDown(Keys.Right);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Space);
                Get_keyboard.KeyUp(Keys.Right);

            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_texts_up()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Up);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Up);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_texts_down()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Down);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Down);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_texts_left()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Left);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Left);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Select_texts_right()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Right);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Right);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Open_start_screen()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Escape);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyDown(Keys.Escape);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Open_task_manager()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Shift);
                Get_keyboard.KeyDown(Keys.Escape);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyUp(Keys.Shift);
                Get_keyboard.KeyDown(Keys.Escape);
            }
            catch
            {
                test = false;
            }
            return test;
        }

        bool Switch_keyboard_layout()
        {
            bool test = true;

            try
            {
                Get_keyboard.KeyDown(Keys.Control);
                Get_keyboard.KeyDown(Keys.Shift);
                Get_keyboard.KeyUp(Keys.Control);
                Get_keyboard.KeyDown(Keys.Shift);
            }
            catch
            {
                test = false;
            }
            return test;
        }
    }
}