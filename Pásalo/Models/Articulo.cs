using System.ComponentModel.DataAnnotations;

namespace Pásalo.Models
{
    public class Articulo : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El artículo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El artículo no puede superar los 100 caracteres.")]
        [Display(Name = "Artículo")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La condición es obligatoria.")]
        [Display(Name = "Condición")]
        public string Condicion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        [StringLength(150, ErrorMessage = "La ubicación no puede superar los 150 caracteres.")]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Display(Name = "Teléfono")]
        [RegularExpression(@"^(809|829|849)([0-9]{7}|-[0-9]{3}-[0-9]{4})$", ErrorMessage = "Introduce un teléfono válido de 10 dígitos.")]
        public string Telefono { get; set; } = string.Empty;

        public bool Disponible { get; set; } = true;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!OpcionesArticulo.Categorias.Contains(Categoria))
            {
                yield return new ValidationResult("Selecciona una categoría válida.", new[] { nameof(Categoria) });
            }

            if (!OpcionesArticulo.Condiciones.Contains(Condicion))
            {
                yield return new ValidationResult("Selecciona una condición válida.", new[] { nameof(Condicion) });
            }
        }
    }
}