using Microsoft.Maui.Controls;

namespace pantallas
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//dashboard");
        }

        private async void OnEntrenamientoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//entrenamiento");
        }

        private async void OnNutricionClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//nutricion");
        }

        private async void OnChatClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//chat");
        }
    }
}
