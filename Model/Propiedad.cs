using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropiedadesBlazor.Model;

public class Propiedad
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Descripcion { get; set; }

    [Required]
    public string Area { get; set; }

    [Required]
    public string Habitaciones { get; set; }

    [Required]
    public string Banios { get; set; }

    [Required]
    public int Parqueadero { get; set; }

    [Required]
    public decimal Precio { get; set; }

    [Required]
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaActualizacion { get; set; }

    // relacion con Categoria
    [ForeignKey("CategoriaId")]
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}
