using PropiedadesBlazor.Model.DTO;

namespace PropiedadesBlazor.Repositorio.IRepositorio;

public interface IPropiedadRepositorio
{
    public Task<IEnumerable<PropiedadDTO>> GettAllPropiedades();
    public Task<PropiedadDTO> GetPropiedadById(int PropiedadId);
    public Task<PropiedadDTO> CrearPropiedad(PropiedadDTO Propiedad);

    public Task<PropiedadDTO> ActualizarPropiedad(PropiedadDTO Propiedad);
    public Task<PropiedadDTO> NombrePropiedadExiste(string Nombre);
    public Task<int> BorrarPropiedad(int PropiedadId);
}
