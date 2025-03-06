using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Model.DTO;

public class CategoriaDTO
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El Nombre es obligatorio")]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}
