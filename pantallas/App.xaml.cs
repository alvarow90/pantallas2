using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace pantallas
{
    public partial class App : Application
    {
        public static Services.DatabaseService BaseDeDatos { get; private set; }
        public static Models.Usuario? UsuarioActual { get; set; }

        public App()
        {
            InitializeComponent();

            string rutaDB = Path.Combine(FileSystem.AppDataDirectory, "usuarios.db");
            BaseDeDatos = new Services.DatabaseService(rutaDB);

            MainPage = new NavigationPage(new AuthPage());
        }
    }
}
