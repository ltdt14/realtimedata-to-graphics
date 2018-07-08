using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ControlRoom.ViewModels;

namespace ControlRoom.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}