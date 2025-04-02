using Microsoft.Maui.Controls;
using System;

namespace pantallas
{
    public partial class Entrenador : ContentPage
    {
        // Variable para guardar el entrenador seleccionado
        private string selectedTrainer = null;

        public Entrenador()
        {
            InitializeComponent();
        }

        // Manejador para el bot?n de retroceso (backarrow)
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Manejador para los recuadros de entrenadores
        private async void OnTrainerTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {


                // Cambia el color del recuadro pulsado para indicar selecci?n
                frame.BackgroundColor = Color.FromArgb("#C0C0C0");

                // Extrae el nombre del entrenador del Label contenido en el Frame
                if (frame.Content is Label label)
                {
                    selectedTrainer = label.Text;
                    await DisplayAlert("Entrenador seleccionado", $"{selectedTrainer} seleccionado", "OK");
                }
            }
        }

        // Manejador para el bot?n de Confirmar Selecci?n
        private async void OnConfirmSelectionClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTrainer))
            {
                await DisplayAlert("Error", "Por favor, selecciona un entrenador primero.", "OK");
            }
            else
            {
                await DisplayAlert("Confirmaci?n", $"Has confirmado a {selectedTrainer} como tu entrenador.", "OK");
                // Aqu? puedes agregar l?gica adicional, como guardar la selecci?n o navegar a otra p?gina.
            }
        }



        // Manejadores para la navegaci?n inferior
        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());
        }



        private async void OnNutricionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Nutricion());
        }

        private void OnChatClicked(object sender, EventArgs e)
        {
            DisplayAlert("Chat", "Abriendo Chat...", "OK");
        }
    }
}
