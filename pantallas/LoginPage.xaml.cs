using System;
using Microsoft.Maui.Controls;

namespace pantallas
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "admin" && password == "1234")
            {
                // Establece AppShell como contenedor principal
                Application.Current.MainPage = new AppShell();

                // Espera un poco a que se cargue el Shell
                await Task.Delay(100);

                // Navega directamente al Dashboard
                await Shell.Current.GoToAsync("//Dashboard");
            }
            else
            {
                MessageLabel.Text = "Usuario o contraseña incorrectos";
            }
        }
    }
}
