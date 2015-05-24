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
using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Exceptions;

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

        // Myo
        
        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            InitializeComponent();

            //Myo
            var channel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create()));
            var hub = Hub.Create(channel);

            hub.MyoConnected += (sender, e) =>
            {
                //set a bpoint here, doesn't get triggered
                this.Dispatcher.Invoke((Action)(() =>
                {
                    //Console.WriteLine("Myo {0} has connected!", e.Myo.Handle);
                    e.Myo.Vibrate(VibrationType.Short);

                }));
            };

            // listen for when the Myo disconnects
            hub.MyoDisconnected += (sender, e) =>
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    //Console.WriteLine("Oh no! It looks like {0} arm Myo has disconnected!", e.Myo.Arm);
                    e.Myo.Vibrate(VibrationType.Medium);
                }));
            };

            // start listening for Myo data
            channel.StartListening();
            Connect_Myo.UserInputLoop(hub);

            //LeapMotion
            controller.SetPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES); // Leap Background
            controller.AddListener(leapmotion_listener);
            
            //Keyboard
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
