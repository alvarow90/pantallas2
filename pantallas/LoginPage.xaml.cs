using System;
using Microsoft.Maui.Controls;

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

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageLabel.Text = "Por favor, completa todos los campos.";
                return;
            }

            // ✅ Usar el método correcto definido en DatabaseService
            var usuario = await App.BaseDeDatos.ValidarLoginAsync(username, password);

            if (usuario != null)
            {
                App.UsuarioActual = usuario;

                Application.Current.MainPage = new AppShell();
                await Task.Delay(100); // opcional, da tiempo a inicializar el Shell
                await Shell.Current.GoToAsync("//Dashboard");
            }
            else
            {
                MessageLabel.Text = "Usuario o contraseña incorrectos";
            }
        }
    }
}
