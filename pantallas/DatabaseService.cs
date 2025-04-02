using System.Threading.Tasks;
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

        // Insertar usuario directamente (sin validación previa)
        public Task<int> AgregarUsuarioAsync(Usuario usuario)
        {
            return _db.InsertAsync(usuario);
        }

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

        // Obtener usuario por ID
        public Task<Usuario?> ObtenerUsuarioPorIdAsync(int id)
        {
            return _db.Table<Usuario>()
                      .Where(u => u.Id == id)
                      .FirstOrDefaultAsync();
        }

        // Registrar nuevo usuario solo si no existe previamente
        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            var existente = await ObtenerUsuarioPorCorreoAsync(usuario.Correo);

            if (existente != null)
                return false; // Ya existe un usuario con ese correo

            await _db.InsertAsync(usuario);
            return true;
        }

        // Actualizar datos del usuario
        public Task<int> ActualizarUsuarioAsync(Usuario usuario)
        {
            return _db.UpdateAsync(usuario);
        }

        // Eliminar usuario por ID
        public Task<int> EliminarUsuarioAsync(int id)
        {
            return _db.DeleteAsync<Usuario>(id);
        }
    }
}
