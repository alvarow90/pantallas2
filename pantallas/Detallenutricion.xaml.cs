using Microsoft.Maui.Controls;

namespace pantallas
{
    public partial class Detallenutricion : ContentPage
    {
        public Detallenutricion()
        {
            InitializeComponent(); // Este SÍ va
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
        }
    }
}
