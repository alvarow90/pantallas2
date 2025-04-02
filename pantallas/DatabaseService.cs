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
            _db.CreateTableAsync<Usuario>().Wait();
        }

        public Task<int> AgregarUsuarioAsync(Usuario usuario)
        {
            return _db.InsertAsync(usuario);
        }

        public Task<Usuario> ObtenerUsuarioPorCorreoAsync(string correo)
        {
            return _db.Table<Usuario>()
                      .Where(u => u.Correo == correo)
                      .FirstOrDefaultAsync();
        }

        public Task<Usuario> ValidarLoginAsync(string correo, string contraseña)
        {
            return _db.Table<Usuario>()
                      .Where(u => u.Correo == correo && u.Contraseña == contraseña)
                      .FirstOrDefaultAsync();
        }
    }
}
