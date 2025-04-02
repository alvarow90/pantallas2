using Microsoft.Maui.Controls;
using System;

namespace pantallas
{
    public partial class Ajustes : ContentPage
    {
        public Ajustes()
        {
            InitializeComponent();

            if (App.UsuarioActual != null)
            {
                LabelNombreUsuario.Text = App.UsuarioActual.Nombre;
            }
            else
            {
                LabelNombreUsuario.Text = "Invitado";
            }
        }

        // Manejador para el botón de retroceso (backarrow)
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Manejador para "Cerrar sesión"
        private async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlert("Cerrar sesión",
                "¿Estás seguro de que quieres cerrar sesión?",
                "Sí", "No");

            if (respuesta)
            {
                // Limpiar sesión del usuario
                App.UsuarioActual = null;

                // Redirigir a la pantalla de autenticación
                Application.Current.MainPage = new NavigationPage(new AuthPage());
            }
        }

        // Manejadores para la navegación inferior
        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());
        }

        private async void OnEntrenamientoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entrenador());
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
