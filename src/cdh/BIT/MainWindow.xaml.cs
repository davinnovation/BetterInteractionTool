using System;
using System.Windows;
using System.Windows.Forms;
using BIT.Windows;
using BIT_Functions;
using Shortcut;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using BIT.Connect;
using Leap;

namespace BIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xamlqazwsx
    /// </summary>

    public partial class MainWindow : MetroWindow
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        private readonly MainWindowViewModel _viewModel;

        // Leap Motion
        Connect_Leapmotion leapmotion_listener = new Connect_Leapmotion();
        Controller controller = new Controller();
        
        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            InitializeComponent();
            controller.SetPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES); // Leap Background
            controller.AddListener(leapmotion_listener);

            _hotkeyBinder.Bind(Modifiers.Control, Keys.D).To(HotkeyCallback);
            _hotkeyBinder.Bind(Modifiers.Control, Keys.E).To(HotkeyCallback2);
        }

        private void LaunchSettings(object sender, RoutedEventArgs e)
        {
            new SettingsWindow() { Owner = this }.Show();
        }

        private void LaunchAbout(object sender, RoutedEventArgs e)
        {
            new AboutWindow() { Owner = this }.Show();
        }

        private void HotkeyCallback()
        {
            new Windows_function() { }.Call_Windows();
            /*IntPtr hWndCharmBar = FindWindow("Charm Bar", null);
            if(hWndCharmBar != null)
                ShowWindow(hWndCharmBar, 0);
            else
                ShowWindow(hWndCharmBar, 0);
            */
        }

        private void HotkeyCallback2()
        {
            new Windows_function() { }.Keyboard_space();
            /*IntPtr hWndCharmBar = FindWindow("Charm Bar", null);
            if(hWndCharmBar != null)
                ShowWindow(hWndCharmBar, 0);
            else
                ShowWindow(hWndCharmBar, 0);
            */
        }
    }
}
