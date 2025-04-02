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

        private async void OnForgotPasswordTapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new RecuperarContrasenaPage());
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;

            if (password != confirmPassword)
            {
                RegisterMessageLabel.Text = "Las contraseñas no coinciden.";
                return;
            }

            var client = new HttpClient();
            var firebaseKey = "AIzaSyAWqyBJ58OzMvNEBfnrjRpAEqk_3FPEqwg";

            var payload = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={firebaseKey}",
                content
            );

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                RegisterMessageLabel.TextColor = Colors.Green;
                RegisterMessageLabel.Text = "¡Registro exitoso con Firebase!";
                await Task.Delay(500);
                Application.Current.MainPage = new AppShell();
                await Task.Delay(100);
                await Shell.Current.GoToAsync("//Dashboard");
            }
            else
            {
                RegisterMessageLabel.TextColor = Colors.Red;
                RegisterMessageLabel.Text = "Error al registrar usuario.";
                Console.WriteLine(result); // Para debug
            }
        }

        private async void OnGoogleLoginClicked(object sender, EventArgs e)
        {
            try
            {
                var authResult = await WebAuthenticator.AuthenticateAsync(
                    new Uri("https://accounts.google.com/o/oauth2/v2/auth" +
                            "?client_id=375894805219-r5mkt5br3gelaag2ioapb06fbe6h3kkl.apps.googleusercontent.com" +
                            "&redirect_uri=urn:ietf:wg:oauth:2.0:oob" +
                            "&response_type=token" +
                            "&scope=email%20profile"),
                    new Uri("urn:ietf:wg:oauth:2.0:oob")
                );

                var accessToken = authResult?.AccessToken;

                if (!string.IsNullOrEmpty(accessToken))
                {
                    await DisplayAlert("Google Login", $"¡Sesión iniciada correctamente!", "OK");

                    // Aquí puedes guardar sesión, o validar token con Firebase si deseas

                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync("//Dashboard");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Falló el login: {ex.Message}", "OK");
            }
        }




    }
}
