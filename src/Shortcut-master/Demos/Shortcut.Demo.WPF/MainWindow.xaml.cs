using System;
using System.Windows;
using System.Windows.Forms;
using FunctionSend;

namespace Shortcut.Demo.WPF
{
    public partial class MainWindow : Window
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            _hotkeyBinder.Bind(Modifiers.Control, Keys.F).To(HotkeyCallback);
        }

        private void HotkeyCallback()
        {
            System.Threading.Thread.Sleep(200);
            Functions.Call_Windows();
            /*IntPtr hWndCharmBar = FindWindow("Charm Bar", null);
            if(hWndCharmBar != null)
                ShowWindow(hWndCharmBar, 0);
            else
                ShowWindow(hWndCharmBar, 0);
            */
        }
    }
}

