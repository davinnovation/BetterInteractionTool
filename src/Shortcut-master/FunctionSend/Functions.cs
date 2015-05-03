using System;
using System.Windows.Forms;

namespace FunctionSend
{
    public class Functions
    {
        public static void Call_Windows()
        {
            Keysend.KeyDown(Keys.LWin);
            Keysend.KeyUp(Keys.LWin);
        }
    }
}
