using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Model;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    [Required]
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaModificacion { get; set; }

    // Relacion con propiedad
    public virtual ICollection<Propiedad> Propiedades { get; set; }
}
