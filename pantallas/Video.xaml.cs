using Microsoft.Maui.Controls;
using System;

namespace pantallas
{
    public partial class Video : ContentPage
    {
        public Video()
        {
            InitializeComponent();
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            // Vuelve a la página anterior si usas NavigationPage
            Navigation.PopAsync();
        }
    }
}