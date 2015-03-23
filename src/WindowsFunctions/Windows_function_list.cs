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
    }
}