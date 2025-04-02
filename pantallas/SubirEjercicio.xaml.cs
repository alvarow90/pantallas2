using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pantallas
{
    public partial class SubirEjercicio : ContentPage
    {
        public SubirEjercicio()
        {
            InitializeComponent();
            // Poblar el Picker con una lista de ejemplo de personas
            PersonaPicker.ItemsSource = new List<string>
            {
                "Juan P�rez",
                "Mar�a Garc�a",
                "Carlos L�pez"
            };
        }

        // Manejador para el bot�n de retroceso (backarrow)
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Manejador para el bot�n "Subir"
        private async void OnSubirClicked(object sender, EventArgs e)
        {
            // Aqu� puedes implementar la l�gica para subir la rutina
            // Por ejemplo, validar datos, enviar informaci�n al servidor, etc.
            await DisplayAlert("Subir Ejercicio", "Ejercicios subidos correctamente.", "OK");
        }
    }
}
