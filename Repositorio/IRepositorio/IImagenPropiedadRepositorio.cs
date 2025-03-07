using PropiedadesBlazor.Model.DTO;

namespace PropiedadesBlazor.Repositorio.IRepositorio;

public interface IImagenPropiedadRepositorio
{
    public Task<int> CrearPropiedadImagen(ImagenPropiedadDTO imagenDto);
    public Task<int> BorrarPropiedadByIdImagen(int imagenId);
    public Task<int> BorrarPropiedadByIdPropiedad(int propieadadId);
    public Task<int> BorrarPropiedadByUrlImagen(int ImagenUrl);
    public Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propieadadId);
}
