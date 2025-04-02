using SQLite;

namespace pantallas.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(100), Unique]
        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public string Rol { get; set; }
    }
}

