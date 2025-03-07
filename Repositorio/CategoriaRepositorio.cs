using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Model;
using PropiedadesBlazor.Model.DTO;
using PropiedadesBlazor.Repositorio.IRepositorio;

namespace PropiedadesBlazor.Repositorio;

public class CategoriaRepositorio : ICategoriaRepositorio
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoriaRepositorio(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CategoriaDTO> ActualizarCategoria(CategoriaDTO categoriaDTO)
    {
        try
        {
            var cat = await _dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == categoriaDTO.Id);

            if (cat == null)
            {
                return new CategoriaDTO();
            }

            var categoria = _mapper.Map(categoriaDTO, cat);
            categoria.FechaModificacion = DateTime.Now;
            var categoriaActualizada = _dbContext.Categorias.Update(categoria);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Categoria, CategoriaDTO>(categoriaActualizada.Entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> BorrarCategoria(int categoriaId)
    {
        try
        {
            var categoria = await _dbContext.Categorias.FindAsync(categoriaId);
            if (categoria is null)
            {
                return 0;
            }

            _dbContext.Categorias.Remove(categoria);
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO)
    {
        var categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
        categoria.FechaCreacion = DateTime.Now;
        var categoriaCreada = await _dbContext.Categorias.AddAsync(categoria);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<Categoria, CategoriaDTO>(categoriaCreada.Entity);
    }

    public async Task<CategoriaDTO> GetCategoriaById(int categoriaId)
    {
        CategoriaDTO categoriaDTO = _mapper.Map<Categoria, CategoriaDTO>(
            await _dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == categoriaId)
        );

        return categoriaDTO;
    }

    public async Task<IEnumerable<DropDownCategoriaDTO>> GetDropDownCategorias()
    {
        try
        {
            IEnumerable<DropDownCategoriaDTO> DropDownCategoriaDTO = _mapper.Map<
                IEnumerable<Categoria>,
                IEnumerable<DropDownCategoriaDTO>
            >(await _dbContext.Categorias.ToListAsync());
            return DropDownCategoriaDTO;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<CategoriaDTO>> GettAllCategorias()
    {
        try
        {
            IEnumerable<CategoriaDTO> categoriaDTO = _mapper.Map<
                IEnumerable<Categoria>,
                IEnumerable<CategoriaDTO>
            >(_dbContext.Categorias.ToList());
            return categoriaDTO;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CategoriaDTO> NombreCategoriaExiste(string Nombre)
    {
        try
        {
            CategoriaDTO categoriaDTO = _mapper.Map<Categoria, CategoriaDTO>(
                await _dbContext.Categorias.FirstOrDefaultAsync(c =>
                    c.Nombre.ToLower().Trim() == Nombre.ToLower().Trim()
                )
            );

            return categoriaDTO;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
