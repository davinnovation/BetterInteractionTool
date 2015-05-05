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

        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            InitializeComponent();
            
            Connect_Leapmotion leapmotion_listener = new Connect_Leapmotion();
            Controller controller = new Controller();
            controller.AddListener(leapmotion_listener);

            _hotkeyBinder.Bind(Modifiers.Control, Keys.F).To(HotkeyCallback);
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
            System.Threading.Thread.Sleep(200);
            Windows_function.Call_Windows();
            /*IntPtr hWndCharmBar = FindWindow("Charm Bar", null);
            if(hWndCharmBar != null)
                ShowWindow(hWndCharmBar, 0);
            else
                ShowWindow(hWndCharmBar, 0);
            */
        }
    }
}
