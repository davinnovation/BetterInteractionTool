using System;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using BIT.Windows;

namespace BIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xamlqazwsx
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            InitializeComponent();
        }

        private void LaunchSettings(object sender, RoutedEventArgs e)
        {
            new SettingsWindow() { Owner = this }.Show();
        }

        private void LaunchAbout(object sender, RoutedEventArgs e)
        {
            new AboutWindow() { Owner = this }.Show();
        }
    }
}
