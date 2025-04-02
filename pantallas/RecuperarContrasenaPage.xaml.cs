using Microsoft.Maui.Controls;
using pantallas.Models;
using System;

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
            string email = EmailRecoveryEntry.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(email))
            {
                RecoveryMessageLabel.TextColor = Colors.Red;
                RecoveryMessageLabel.Text = "Por favor, ingresa tu correo.";
                return;
            }

            // Verifica si el correo está registrado en la base de datos
            Usuario? usuario = await App.BaseDeDatos.ObtenerUsuarioPorCorreoAsync(email);

            if (usuario == null)
            {
                RecoveryMessageLabel.TextColor = Colors.Red;
                RecoveryMessageLabel.Text = "Este correo no está registrado.";
                return;
            }

            // Simulación de envío de correo
            await DisplayAlert("Recuperación enviada", $"Se enviaron instrucciones a {email}", "OK");

            RecoveryMessageLabel.TextColor = Colors.Green;
            RecoveryMessageLabel.Text = "Revisa tu correo electrónico.";
        }
    }
}
