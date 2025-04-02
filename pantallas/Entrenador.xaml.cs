using Microsoft.Maui.Controls;
using System;

namespace pantallas
{
    public partial class Entrenador : ContentPage
    {
        // Variable para guardar el nombre del entrenador seleccionado
        private string? nombre = null;

        public Entrenador()
        {
            InitializeComponent();
        }

        // Manejador para el botón de retroceso (backarrow)
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Manejador para los recuadros de entrenadores
        private async void OnTrainerTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                // Cambia el color del recuadro pulsado para indicar selección
                frame.BackgroundColor = Color.FromArgb("#C0C0C0");

                // Extrae el nombre del entrenador del Label contenido en el Frame
                if (frame.Content is Label label)
                {
                    nombre = label.Text;
                    await DisplayAlert("Entrenador seleccionado", $"{nombre} seleccionado", "OK");
                }
            }
        }

        // Manejador para el botón de Confirmar Selección
        private async void OnConfirmSelectionClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                await DisplayAlert("Error", "Por favor, selecciona un entrenador primero.", "OK");
            }
            else
            {
                await DisplayAlert("Confirmación", $"Has confirmado a {nombre} como tu entrenador.", "OK");

                // Aquí puedes guardar la selección, asignarla al usuario, etc.
            }
        }

        // Manejadores para la navegación inferior
        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());
        }

        private async void OnNutricionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Nutricion());
        }

        private async void OnChatClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Chat", "Abriendo Chat...", "OK");
        }
    }
}
