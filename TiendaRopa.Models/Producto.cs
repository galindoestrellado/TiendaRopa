using System.ComponentModel.DataAnnotations;

namespace TiendaRopa.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Talla obligatoria")]
        [Range(1, 10, ErrorMessage = "Talla debe estar en el rango 1-10")]
        public int Talla { get; set; }

        [Required(ErrorMessage = "Color obligatorio")]
        [StringLength(30, ErrorMessage = "El color no puede tener más de 30 caracteres.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Precio obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Descripción obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede tener más de 200 caracteres.")]
        public string Descripcion { get; set; }
    }
}
