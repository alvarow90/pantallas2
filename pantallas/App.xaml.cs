using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace pantallas
{
    public partial class App : Application
    {
        public App()
        {

            //MainPage = new NavigationPage(new AuthPage());
            MainPage = new AppShell();
            // Mostrar primero la pantalla de Login
        }
    }
}
