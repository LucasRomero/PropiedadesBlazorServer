using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropiedadesBlazor.Model;

public class ImagenPropiedad
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("PropiedadId")]
    public int PropiedadId { get; set; }
    public string UrlImagenPropiedad { get; set; }

    public virtual Propiedad propiedad { get; set; }
}
