using System.ComponentModel.DataAnnotations;

namespace TiendaWedDiaz.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Estado { get; set; }
//        [Required(ErrorMessage = "El nombre es obligatorio")]
//        public string Nombre { get; set; } = string.Empty;
    }
}
