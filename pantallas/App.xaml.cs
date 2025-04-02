using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.IO;
using pantallas.Services;
using pantallas.Models;

namespace pantallas
{
    public partial class App : Application
    {
        // Servicio de base de datos SQLite
        public static DatabaseService BaseDeDatos { get; private set; } = null!;

        // Usuario logueado actualmente
        public static Usuario? UsuarioActual { get; set; }

        public App()
        {
            InitializeComponent();

            // Ruta local de la base de datos
            string rutaDB = Path.Combine(FileSystem.AppDataDirectory, "usuarios.db");

            // Inicializa el servicio de base de datos
            BaseDeDatos = new DatabaseService(rutaDB);

            // Establece la página principal: pantalla de autenticación
            MainPage = new AuthPage(); // Se cambiará a AppShell() al iniciar sesión
        }

        protected override void OnStart()
        {
            // Aquí puedes poner lógica adicional al iniciar
        }

        protected override void OnSleep()
        {
            // Aquí puedes guardar datos o liberar recursos
        }

        protected override void OnResume()
        {
            // Lógica al reanudar la app
        }
    }
}
