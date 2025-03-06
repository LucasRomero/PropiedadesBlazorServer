using PropiedadesBlazor.Model.DTO;

namespace PropiedadesBlazor.Repositorio.IRepositorio;

public interface ICategoriaRepositorio
{
    public Task<IEnumerable<CategoriaDTO>> GettAllCategorias();
    public Task<CategoriaDTO> GetCategoriaById(int categoriaId);
    public Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoria);

    public Task<CategoriaDTO> ActualizarCategoria(CategoriaDTO categoria);
    public Task<CategoriaDTO> NombreCategoriaExiste(string Nombre);
    public Task<int> BorrarCategoria(int categoriaId);
    public Task<IEnumerable<CategoriaDTO>> GetDropDownCategorias(int categoriaId);
}
