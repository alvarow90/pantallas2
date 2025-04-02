using System.Text.Json;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace pantallas
{
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
        }


        private void OnLoginTabClicked(object sender, EventArgs e)
        {
            LoginForm.IsVisible = true;
            RegisterForm.IsVisible = false;

            LoginTabButton.BackgroundColor = Colors.White;
            LoginTabButton.TextColor = Colors.Black;
            RegisterTabButton.BackgroundColor = Colors.Transparent;
            RegisterTabButton.TextColor = Colors.Gray;

            // Limpia los campos de login
            LoginEmailEntry.Text = string.Empty;
            LoginPasswordEntry.Text = string.Empty;
        }

        private void OnRegisterTabClicked(object sender, EventArgs e)
        {
            LoginForm.IsVisible = false;
            RegisterForm.IsVisible = true;

            LoginTabButton.BackgroundColor = Colors.Transparent;
            LoginTabButton.TextColor = Colors.Gray;
            RegisterTabButton.BackgroundColor = Colors.White;
            RegisterTabButton.TextColor = Colors.Black;

            // Limpia los campos del registro
            NameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
            ConfirmPasswordEntry.Text = string.Empty;
            RolePicker.SelectedIndex = -1;
            RegisterMessageLabel.Text = string.Empty;
        }



        private async void OnForgotPasswordTapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new RecuperarContrasenaPage());
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string nombre = NameEntry.Text?.Trim();
            string correo = EmailEntry.Text?.Trim();
            string contraseña = PasswordEntry.Text;
            string confirmar = ConfirmPasswordEntry.Text;
            string rol = RolePicker.SelectedItem?.ToString();

            if (contraseña != confirmar || string.IsNullOrWhiteSpace(correo))
            {
                RegisterMessageLabel.TextColor = Colors.Red;
                RegisterMessageLabel.Text = "Contraseñas no coinciden o datos incompletos.";
                return;
            }

            var usuarioExistente = await App.BaseDeDatos.ObtenerUsuarioPorCorreoAsync(correo);
            if (usuarioExistente != null)
            {
                RegisterMessageLabel.TextColor = Colors.Red;
                RegisterMessageLabel.Text = "Este correo ya está registrado.";
                return;
            }

            var usuario = new Models.Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseña,
                Rol = rol
            };

            await App.BaseDeDatos.AgregarUsuarioAsync(usuario);

            RegisterMessageLabel.TextColor = Colors.Green;
            RegisterMessageLabel.Text = "¡Registro exitoso!";
            await Task.Delay(500);

            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//Dashboard");
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string correo = LoginEmailEntry.Text?.Trim();
            string contraseña = LoginPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contraseña))
            {
                await DisplayAlert("Error", "Correo y contraseña obligatorios.", "OK");
                return;
            }

            var usuario = await App.BaseDeDatos.ValidarLoginAsync(correo, contraseña);

            if (usuario == null)
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
                return;
            }

            // Guardar el usuario actual en una propiedad estática
            App.UsuarioActual = usuario;

            await DisplayAlert("Bienvenido", $"Hola {usuario.Nombre} ({usuario.Rol})", "OK");

            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//Dashboard");
        }






    }
}
