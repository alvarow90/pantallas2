using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace pantallas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AuthPage(); // tu nueva pantalla con login/registro
                                       // Mostrar primero la pantalla de Login
        }
    }
}
