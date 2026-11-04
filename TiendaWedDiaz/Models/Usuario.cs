using System.ComponentModel.DataAnnotations;

namespace TiendaWedDiaz.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        [StringLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El rol es obligatorio")]
        [StringLength(30)]
        public string Rol { get; set; } = string.Empty;

        // 10 dígitos, iniciando con 3
        [Required(ErrorMessage = "El celular es obligatorio")]
        [RegularExpression(@"^3\d{9}$", ErrorMessage = "El celular debe tener 10 dígitos e iniciar con 3")]
        public string Celular { get; set; } = string.Empty;
    }

    public static class Roles
    {
        public const string Administrador = "Administrador";
        public const string Cajero = "Cajero";
        public const string Bodeguero = "Bodeguero";
        public const string Cliente = "Cliente";

        public static readonly string[] Todos = { Administrador, Cajero, Bodeguero, Cliente };
    }
}
