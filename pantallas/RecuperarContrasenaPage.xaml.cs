namespace pantallas
{
    public partial class RecuperarContrasenaPage : ContentPage
    {
        public RecuperarContrasenaPage()
        {
            InitializeComponent();
        }

        private async void OnEnviarClicked(object sender, EventArgs e)
        {
            string email = EmailRecoveryEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                RecoveryMessageLabel.TextColor = Colors.Red;
                RecoveryMessageLabel.Text = "Por favor ingresa tu correo.";
                return;
            }

            // Simulaci�n de env�o
            await DisplayAlert("Recuperaci�n enviada", $"Se enviaron instrucciones a {email}", "OK");

            RecoveryMessageLabel.TextColor = Colors.Green;
            RecoveryMessageLabel.Text = "Revisa tu correo electr�nico.";
        }
    }
}
