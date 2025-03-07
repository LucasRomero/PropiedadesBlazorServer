using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Model.DTO;

public class PropiedadDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El Nombre es obligatorio")]
    [StringLength(
        30,
        MinimumLength = 5,
        ErrorMessage = "El Nombre debe estar entre 5 y 30 caracteres"
    )]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La Descripcion es obligatorio")]
    [StringLength(
        300,
        MinimumLength = 20,
        ErrorMessage = "El Descripcion debe estar entre 20 y 300 caracteres"
    )]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El Area es obligatorio")]
    [Range(1, 5000, ErrorMessage = "Debe ingresar un numero valido")]
    public int Area { get; set; }

    [Required(ErrorMessage = "El Area es obligatorio")]
    [Range(1, 10, ErrorMessage = "Debe ingresar un numero valido")]
    public int Habitaciones { get; set; }

    [Required(ErrorMessage = "Los Banios es obligatorio")]
    [Range(1, 10, ErrorMessage = "Debe ingresar un numero valido")]
    public int Banios { get; set; }

    [Required(ErrorMessage = "Los Parqueadero es obligatorio")]
    [Range(1, 10, ErrorMessage = "Debe ingresar un numero valido")]
    public int Parqueadero { get; set; }

    [Required(ErrorMessage = "El Precio es obligatorio")]
    public decimal Precio { get; set; }

    [Required]
    public bool Activo { get; set; }
    public int CategoriaID { get; set; }
}
