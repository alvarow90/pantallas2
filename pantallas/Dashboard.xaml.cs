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
            await Shell.Current.GoToAsync("//Dashboard");
        }

        private async void OnEntrenamientoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Entrenamiento");
        }

        private async void OnNutricionClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Nutricion");
        }

        private async void OnChatClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Chat");
        }
    }
}
