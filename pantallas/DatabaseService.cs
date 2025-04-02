using SQLite;
using pantallas.Models;

namespace pantallas.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Usuario>().Wait(); // Crea la tabla si no existe
        }

        // Insertar usuario directamente
        public Task<int> AgregarUsuarioAsync(Usuario usuario)
        {
            return _db.InsertAsync(usuario);
        }

        // Obtener usuario por correo (puede retornar null)
        // Obtener usuario por correo (puede retornar null)
        public Task<Usuario?> ObtenerUsuarioPorCorreoAsync(string correo)
        {
            return _db.Table<Usuario>()
                      .Where(u => u.Correo == correo)
                      .FirstOrDefaultAsync();
        }


        // Validar login por correo y contraseña (puede retornar null)
        public Task<Usuario?> ValidarLoginAsync(string correo, string contraseña)
        {
            return _db.Table<Usuario>()
                      .Where(u => u.Correo == correo && u.Contraseña == contraseña)
                      .FirstOrDefaultAsync();
        }


        // Registrar nuevo usuario solo si no existe previamente
        public async Task<bool> RegistrarUsuario(Usuario usuario)
        {
            var existente = await _db.Table<Usuario>()
                                     .Where(u => u.Correo == usuario.Correo)
                                     .FirstOrDefaultAsync();

            if (existente != null)
                return false; // El correo ya está registrado

            await _db.InsertAsync(usuario);
            return true;
        }
    }
}
