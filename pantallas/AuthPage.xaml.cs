using Microsoft.Maui.Controls;

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
    }
}
