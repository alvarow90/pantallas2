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

string rutaDB = Path.Combine(FileSystem.AppDataDirectory, "usuarios.db");

// Inicializa el servicio de base de datos
BaseDeDatos = new DatabaseService(rutaDB);

// Establece la página principal: pantalla de autenticación
MainPage = new NavigationPage(new AuthPage()); // Mostrar primero la pantalla de Login
        }
    }
}
