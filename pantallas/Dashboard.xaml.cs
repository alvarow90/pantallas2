
using Microsoft.Maui.Controls;
namespace pantallas
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent(); // ← Este método lo genera el archivo .g.cs cuando todo está bien
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private async void OnVerDietaCompleta(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Detallenutricion());
        }
        private async void OnVerDetalleEntrenamiento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Detalleentrenamiento());
        }
        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Detalleentrenamiento());
        }
        private async void OnEntrenamientoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPage1());
        }
        private async void OnNutricionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Nutricion());
        }
        private async void OnChatClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Nutricion());
            InitializeComponent();

            // Mostrar saludo personalizado
            if (App.UsuarioActual != null)
            {
                LabelBienvenida.Text = $"Hola, {App.UsuarioActual.Nombre}!";
            }
            else
            {
                LabelBienvenida.Text = "Hola, invitado!";
            }
        }

        
        }
    }
}
