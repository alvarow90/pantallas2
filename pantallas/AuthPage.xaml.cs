using Microsoft.Maui.Controls;
using pantallas.Models;

namespace pantallas
{
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        // LOGIN

        public static Models.Usuario? UsuarioActual { get; set; }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string correo = LoginEmailEntry.Text?.Trim() ?? "";
            string contrasena = LoginPasswordEntry.Text ?? "";

            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
            {
                await DisplayAlert("Error", "Por favor, ingresa tu correo y contraseña.", "OK");
                return;
            }

            var usuario = await App.BaseDeDatos.ValidarLoginAsync(correo, contrasena);

            if (usuario != null)
            {
                App.UsuarioActual = usuario;

                // CAMBIA LA RAÍZ A SHELL
                Application.Current.MainPage = new AppShell();
                await Task.Delay(100); // (opcional)
                await Shell.Current.GoToAsync("//Dashboard");
            }
            else
            {
                await DisplayAlert("Acceso denegado", "Correo o contraseña incorrectos.", "OK");
            }
        }


        // REGISTRO
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string nombre = NameEntry.Text?.Trim() ?? "";
            string correo = EmailEntry.Text?.Trim() ?? "";
            string rol = RolePicker.SelectedItem?.ToString() ?? "";
            string password = PasswordEntry.Text ?? "";
            string confirmPassword = ConfirmPasswordEntry.Text ?? "";

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(rol) || string.IsNullOrWhiteSpace(password))
            {
                RegisterMessageLabel.TextColor = Colors.Red;
                RegisterMessageLabel.Text = "Por favor completa todos los campos.";
                return;
            }

            if (password != confirmPassword)
            {
                RegisterMessageLabel.TextColor = Colors.Red;
                RegisterMessageLabel.Text = "Las contraseñas no coinciden.";
                return;
            }

            var usuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contraseña = password,
                Rol = rol
            };

            bool creado = await App.BaseDeDatos.RegistrarUsuarioAsync(usuario);

            if (creado)
            {
                RegisterMessageLabel.TextColor = Colors.Green;
                RegisterMessageLabel.Text = "Cuenta creada exitosamente. Ahora puedes iniciar sesión.";
                OnLoginTabClicked(null, null); // Cambiar a la pestaña de login
            }
            else
            {
                RegisterMessageLabel.TextColor = Colors.Red;
                RegisterMessageLabel.Text = "El correo ya está registrado.";
            }
        }

        // CAMBIO A PESTAÑA DE INGRESAR
        private void OnLoginTabClicked(object sender, EventArgs e)
        {
            LoginForm.IsVisible = true;
            RegisterForm.IsVisible = false;

            LoginTabButton.BackgroundColor = Colors.White;
            LoginTabButton.TextColor = Colors.Black;
            RegisterTabButton.BackgroundColor = Colors.Transparent;
            RegisterTabButton.TextColor = Colors.Gray;
        }

        // CAMBIO A PESTAÑA DE REGISTRO
        private void OnRegisterTabClicked(object sender, EventArgs e)
        {
            LoginForm.IsVisible = false;
            RegisterForm.IsVisible = true;

            RegisterTabButton.BackgroundColor = Colors.White;
            RegisterTabButton.TextColor = Colors.Black;
            LoginTabButton.BackgroundColor = Colors.Transparent;
            LoginTabButton.TextColor = Colors.Gray;
        }

        // OLVIDÉ MI CONTRASEÑA
        private async void OnForgotPasswordTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecuperarContrasenaPage());
        }
    }
}
