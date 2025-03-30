using System;
using Microsoft.Maui.Controls;

namespace pantallas
{
    public partial class MainPage : ContentPage
    {
        int countDashboard = 0;
        int countEntrenamiento = 0;
        int countNutricion = 0;
        int countChat = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnDashboardClicked(object sender, EventArgs e)
        {
            countDashboard++;
            BtnDashboard.Text = countDashboard == 1 ? "Clicked 1 time" : $"Clicked {countDashboard} times";
        }

        private void OnEntrenamientoClicked(object sender, EventArgs e)
        {
            countEntrenamiento++;
            BtnEntrenamiento.Text = countEntrenamiento == 1 ? "Clicked 1 time" : $"Clicked {countEntrenamiento} times";
        }

        private void OnNutricionClicked(object sender, EventArgs e)
        {
            countNutricion++;
            BtnNutricion.Text = countNutricion == 1 ? "Clicked 1 time" : $"Clicked {countNutricion} times";
        }

        private void OnChatClicked(object sender, EventArgs e)
        {
            countChat++;
            BtnChat.Text = countChat == 1 ? "Clicked 1 time" : $"Clicked {countChat} times";
        }
    }
}
