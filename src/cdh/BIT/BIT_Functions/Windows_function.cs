using System;
using System.Windows.Forms;

namespace BIT_Functions
{
    public class Windows_function
    {
        public static void Call_Windows()
        {
            Keysend.KeyDown(Keys.LWin);
            Keysend.KeyUp(Keys.LWin);
        }
    }
}
