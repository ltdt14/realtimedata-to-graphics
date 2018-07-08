using Avalonia;
using Avalonia.Markup.Xaml;

namespace ControlRoom
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}