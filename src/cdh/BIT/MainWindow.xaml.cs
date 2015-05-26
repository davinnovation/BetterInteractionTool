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
using MyoSharp.Poses;
using MyoSharp.Exceptions;

namespace BIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xamlqazwsx
    /// </summary>

    public partial class MainWindow : MetroWindow
    {
        //private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        
        private readonly MainWindowViewModel _viewModel;

        public FileDB_Connector connecting;
        
        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            InitializeComponent();
            connecting = new FileDB_Connector();
            connecting.Connect_DB_Func();
            
            //Myo
            var channel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create()));
            var hub = Hub.Create(channel);

            hub.MyoConnected += (sender, e) =>
            {
                //set a bpoint here, doesn't get triggered
                this.Dispatcher.Invoke((Action)(() =>
                {
                    Console.WriteLine("Myo {0} has connected!", e.Myo.Handle);
                    e.Myo.Vibrate(VibrationType.Long);

                    // unlock the Myo so that it doesn't keep locking between our poses
                    e.Myo.Unlock(UnlockType.Hold);

                    // setup for the pose we want to watch for
                    var pose = HeldPose.Create(e.Myo, Pose.Fist, Pose.FingersSpread, Pose.DoubleTap, Pose.WaveIn, Pose.WaveOut);

                    // set the interval for the event to be fired as long as 
                    // the pose is held by the user
                    pose.Interval = TimeSpan.FromSeconds(0.5);

                    pose.Start();
                    pose.Triggered += Connect_Myo.Pose_Triggered;
                }));
            };

            // listen for when the Myo disconnects
            hub.MyoDisconnected += (sender, e) =>
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    Console.WriteLine("Oh no! It looks like {0} arm Myo has disconnected!", e.Myo.Arm);
                    e.Myo.Vibrate(VibrationType.Medium);
                }));
            };

            // start listening for Myo data
            channel.StartListening();
            Connect_Myo.UserInputLoop(hub);    
        }

        private void LaunchSettings(object sender, RoutedEventArgs e)
        {
            new SettingsWindow() { Owner = this }.Show();
        }

        private void LaunchAbout(object sender, RoutedEventArgs e)
        {
            new AboutWindow() { Owner = this }.Show();
        }

        public void Call_FileDB_Connect()
        {
            connecting.Connect_DB_Func();
        }
    }
}
