using Microsoft.Maui.Controls;
using System;

namespace pantallas
{
    public partial class NewPage1 : ContentPage
    {
        public NewPage1()
        {
            InitializeComponent();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            // Navega a la p�gina Dashboard
            await Navigation.PushAsync(new Dashboard());
        }

        private async void OnEntrenamientoClicked(object sender, EventArgs e)
        {
            // Navega a la p�gina de Entrenamiento (en este ejemplo se recarga la misma p�gina)
            await Navigation.PushAsync(new NewPage1());
        }

        private async void OnNutricionClicked(object sender, EventArgs e)
        {
            // Navega a la p�gina Nutricion
            await Navigation.PushAsync(new Nutricion());
        }

        private void OnChatClicked(object sender, EventArgs e)
        {
            // Muestra una alerta en lugar de navegar a una nueva p�gina
            DisplayAlert("Chat", "Abriendo Chat...", "OK");
        }

        private void OnCheckTapped(object sender, EventArgs e)
        {
            if (sender is BoxView box)
            {
                // Alterna el color entre negro y verde
                box.Color = box.Color == Colors.Black ? Colors.Green : Colors.Black;
            }
        }

        // M�todo que se invoca al pulsar el primer ejercicio
        private async void OnFirstExerciseTapped(object sender, EventArgs e)
        {
            // Navega a la p�gina Video (aseg�rate de que la clase Video exista en el proyecto)
            await Navigation.PushAsync(new Video());
        }
    }
}