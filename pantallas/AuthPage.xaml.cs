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
        }

        private void OnRegisterTabClicked(object sender, EventArgs e)
        {
            LoginForm.IsVisible = false;
            RegisterForm.IsVisible = true;
            LoginTabButton.BackgroundColor = Colors.Transparent;
            LoginTabButton.TextColor = Colors.Gray;
            RegisterTabButton.BackgroundColor = Colors.White;
            RegisterTabButton.TextColor = Colors.Black;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text?.Trim();
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;
            string role = RolePicker.SelectedItem?.ToString();

            // Validaciones
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(role))
            {
                RegisterMessageLabel.TextColor = Colors.Red;
                RegisterMessageLabel.Text = "Todos los campos son obligatorios.";
                return;
            }

            if (password != confirmPassword)
            {
                RegisterMessageLabel.TextColor = Colors.Red;
                RegisterMessageLabel.Text = "Las contraseñas no coinciden.";
                return;
            }

            // Simulación de guardado
            Console.WriteLine($"[REGISTRO] Nombre: {name}, Email: {email}, Rol: {role}");

            RegisterMessageLabel.TextColor = Colors.Green;
            RegisterMessageLabel.Text = $"¡Registro exitoso como {role}!";

            await Task.Delay(500);

            Application.Current.MainPage = new AppShell();
            await Task.Delay(100);
            await Shell.Current.GoToAsync("//Dashboard");
        }

    }
}
